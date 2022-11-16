from flask import Flask, render_template, request, redirect, url_for, Response, session, jsonify, Markup
import flask 
from flask_mysqldb import MySQL
from config import Config as cfg
frm_inventario_fisico_erp=flask.Blueprint('frm_inventario_fisico_erp', __name__)
app = Flask(__name__, template_folder="templates")
app.debug = True
app.secret_key = cfg.SECRET_KEY
mysql=MySQL(app)
registros=0
pos=0
fil=""
@frm_inventario_fisico_erp.route('/frm_inventario_fisico_erp_act/<operacion>', methods=['POST'])
def frm_inventario_fisico_erp_act(operacion): 
    print('Begin frm_inventario_fisico_erp_act():..')
    id_empresa=str(request.form['id_empresa'])
    id_bodega=str(request.form['id_bodega'])
    id_producto=str(request.form['id_producto'])
    conteo_1=str(request.form['conteo_1'])
    conteo_2=str(request.form['conteo_2'])
    conteo_3=str(request.form['conteo_3'])
    if operacion=="Crear":
       sql = "insert into inventario_fisico_erp (id_empresa, id_bodega, id_producto, conteo_1, conteo_2, conteo_3) values (" + str(session['id_empresa']) + ","  + "'" + id_bodega + "'" + ","  + "'" + id_producto + "'" + ","  + conteo_1 + ","  + conteo_2 + ","  + conteo_3 + ")"
       print("sql:", sql)
       cur = mysql.connection.cursor()
       print("cursor")
       try:
          cur.execute(sql)
          print("ejecuto sql")
          mysql.connection.commit()
       except cur.Error as err:
          print("except:", err)
          errores="Clave ya existe."        
          bloquea_campos=''
          bloquea_claves=''
          print("va para render")
          reg={}
          reg['id_empresa']=id_empresa
          reg['id_bodega']=id_bodega
          reg['id_producto']=id_producto
          reg['conteo_1']=conteo_1
          reg['conteo_2']=conteo_2
          reg['conteo_3']=conteo_3
          titulo="Registro inventario_fisico_erp: arregle las inconsistencias"
          valida=""
          return render_template('frm_inventario_fisico_erp_show.html', reg=reg, bloquea_campos=bloquea_campos, bloquea_claves=bloquea_claves, operacion=operacion, errores=errores, titulo=titulo, valida=valida)
    if operacion=="Modificar":
       sql = "update inventario_fisico_erp set conteo_1 = " +  conteo_1 + "," + " conteo_2 = " +  conteo_2 + "," + " conteo_3 = " +  conteo_3  + " where id_empresa = " +  str(session['id_empresa']) + " and  id_bodega = '" +  id_bodega + "'" + " and  id_producto = '" +  id_producto + "'"
       print("sql:", sql)
       cur = mysql.connection.cursor()
       cur.execute(sql)
       mysql.connection.commit()
    if operacion=="Eliminar":
       sql = "delete from  inventario_fisico_erp where id_empresa = " + str(session['id_empresa']) + " and  id_bodega = '" + id_bodega + "'" + " and  id_producto = '" + id_producto + "'"
       print("sql:", sql)
       cur = mysql.connection.cursor()
       cur.execute(sql)
       mysql.connection.commit()
    print ("va para frm_inventario_fisico_erp_list")
    errores=""
    titulo="Registro inventario_fisico_erp"
    return redirect(url_for('frm_inventario_fisico_erp.frm_inventario_fisico_erp_primero'))
    
@frm_inventario_fisico_erp.route('/frm_inventario_fisico_erp_show/<ope>/<id_empresa>/<id_bodega>/<id_producto>', methods=['GET'])
def frm_inventario_fisico_erp_show(ope, id_empresa, id_bodega, id_producto): 
    print("Begin frm_inventario_fisico_erp_show(): ope=", ope)
    valida=""
    
    if ope== "M" or ope == "E":
       sql = "select * from inventario_fisico_erp where id_empresa = " + str(session['id_empresa']) + " and  id_bodega = '" + id_bodega+ "'" + " and  id_producto = '" + id_producto+ "'"
       #sql = "SELECT * FROM canales where id = '"+str(clave)+"'"
       print("sql:",sql)
       cur = mysql.connection.cursor()
       cur.execute(sql)
       registro = cur.fetchone()
       bloquea_claves = "readonly"
       bloquea_campos=""
       operacion="Modificar"
       if ope=="E":
          bloquea_campos = "readonly"
          operacion="Eliminar"
          valida="novalidate"
    else:
       bloquea_claves = ""
       bloquea_campos =""
       registro={}
       registro['id_empresa']=session['id_empresa']
       operacion="Crear"
    titulo="Registro inventario_fisico_erp: "+ operacion
    print("registro:", registro)
    errores=""
    return render_template('frm_inventario_fisico_erp_show.html', reg=registro, bloquea_campos=bloquea_campos, bloquea_claves=bloquea_claves, operacion=operacion, errores=errores, titulo=titulo, valida=valida)
@frm_inventario_fisico_erp.route('/frm_inventario_fisico_erp_primero', methods=['GET'])
def frm_inventario_fisico_erp_primero(): 
    print('Begin frm_inventario_fisico_erp_primero()...')
    if "user_id" not in session:
       return redirect(url_for('login'))
    global registros
    pos=0
    sql="SELECT count(*) as registros from inventario_fisico_erp where id_empresa = " + str(session['id_empresa'])
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchone()
    registros=tabla['registros']
    reg=25
    print("registros:",registros)
    #sql = 'SELECT * FROM inventario_fisico_erp limit ' + str(pos) + ', ' + str(reg)  
    sql = "SELECT * FROM inventario_fisico_erp WHERE id_empresa = " + str(session['id_empresa']) + ' limit ' + str(pos) + ', ' + str(reg)  
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchall()
    if len(tabla) >= 0:
       navega = 's'
       return render_template('frm_inventario_fisico_erp_list.html', orders=tabla, navega=navega)
    else:
       print('Error al listar inventario_fisico_erp')
       return render_template('error.html', errores='Error al listar canales. ', pos=pos)
def arma_filtro(filtro):
    print("Begin arma_filtro():...")
    fil = " and  ( id_bodega like '%" + filtro + "%'" 
    fil = fil + " or id_producto like '%" + filtro + "%'" 
    fil = fil + " or conteo_1 like '%" + filtro + "%'" 
    fil = fil + " or conteo_2 like '%" + filtro + "%'" 
    fil = fil + " or conteo_3 like '%" + filtro + "%'" 
    fil = fil + ")" 
    return fil
@frm_inventario_fisico_erp.route('/frm_inventario_fisico_erp_list', methods=['POST'])
def frm_inventario_fisico_erp_list(): 
    print('Begin frm_empresas_list()...')
    if "user_id" not in session:
       return redirect(url_for('login'))
    global registros, fil, pos
    #print("filter", request.form['filter'])
    #print("request.form.btn_filtro:",request.form['btn_filtro'])    
    print("pos:",pos)
    #print("request.form[btn_filtro]:",request.form['btn_filtro'])
    accion=request.form['btn_filtro']
    if accion=="primero":
       pos = 0
    if accion=="anterior":
       pos = pos - 25
    if accion=="siguiente":
       pos = pos + 25       
    if accion=="ultimo":
       pos = 99999
    if fil != request.form['filter']:
       pos = 0
    print("accion: ", accion, " ", pos)
    fil=request.form['filter']
    if  len(request.form['filter'])>0:
        filtro=arma_filtro(fil)
    else: 
        filtro=""
    if pos==0:
       sql="SELECT count(*) as registros from inventario_fisico_erp WHERE id_empresa = " + str(session['id_empresa']) + " " + filtro
       cur = mysql.connection.cursor()
       cur.execute(sql)
       tabla = cur.fetchone()
       registros=tabla['registros']
    reg=25
    print("registros:",registros)
    #posi=int(pos)   
    if pos < 0:
       pos = 0   
    if pos==99999:
       pos=int(registros/reg)*reg
    if pos>registros:
       pos=int(registros/reg)*reg
    print("pos:",pos)
    sql = "SELECT * FROM inventario_fisico_erp WHERE id_empresa = " + str(session['id_empresa']) + " " + filtro + " limit " + str(pos) + ", " + str(reg)  
    print("sql:", sql)
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchall()
    if len(tabla) >= 0:
       navega = 's'
       return render_template('frm_inventario_fisico_erp_list.html', orders=tabla, navega=navega, fil=fil)
    else:
       print('Error al listar empresas')
       return render_template('error.html', errores='Error al listar canales. ', pos=pos, fil=fil)
