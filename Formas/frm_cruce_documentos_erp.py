from flask import Flask, render_template, request, redirect, url_for, Response, session, jsonify, Markup
import flask 
from flask_mysqldb import MySQL
from config import Config as cfg
frm_cruce_documentos_erp=flask.Blueprint('frm_cruce_documentos_erp', __name__)
app = Flask(__name__, template_folder="templates")
app.debug = True
app.secret_key = cfg.SECRET_KEY
mysql=MySQL(app)
registros=0
pos=0
fil=""
@frm_cruce_documentos_erp.route('/frm_cruce_documentos_erp_act/<operacion>', methods=['POST'])
def frm_cruce_documentos_erp_act(operacion): 
    print('Begin frm_cruce_documentos_erp_act():..')
    id_empresa=str(request.form['id_empresa'])
    id=str(request.form['id'])
    tipo_cr=str(request.form['tipo_cr'])
    id_cr=str(request.form['id_cr'])
    tipo_db=str(request.form['tipo_db'])
    id_db=str(request.form['id_db'])
    fecha=str(request.form['fecha'])
    valor=str(request.form['valor'])
    retencion=str(request.form['retencion'])
    rete_iva=str(request.form['rete_iva'])
    rete_ica=str(request.form['rete_ica'])
    ajuste=str(request.form['ajuste'])
    observaciones=str(request.form['observaciones'])
    if operacion=="Crear":
       sql = "insert into cruce_documentos_erp (id_empresa, id, tipo_cr, id_cr, tipo_db, id_db, fecha, valor, retencion, rete_iva, rete_ica, ajuste, observaciones) values (" + str(session['id_empresa']) + ","  + id + ","  + "'" + tipo_cr + "'" + ","  + id_cr + ","  + "'" + tipo_db + "'" + ","  + id_db + ","  + "'" + fecha + "'" + ","  + valor + ","  + retencion + ","  + rete_iva + ","  + rete_ica + ","  + ajuste + ","  + "'" + observaciones + "'" + ")"
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
          reg['id']=id
          reg['tipo_cr']=tipo_cr
          reg['id_cr']=id_cr
          reg['tipo_db']=tipo_db
          reg['id_db']=id_db
          reg['fecha']=fecha
          reg['valor']=valor
          reg['retencion']=retencion
          reg['rete_iva']=rete_iva
          reg['rete_ica']=rete_ica
          reg['ajuste']=ajuste
          reg['observaciones']=observaciones
          titulo="Registro cruce_documentos_erp: arregle las inconsistencias"
          valida=""
          return render_template('frm_cruce_documentos_erp_show.html', reg=reg, bloquea_campos=bloquea_campos, bloquea_claves=bloquea_claves, operacion=operacion, errores=errores, titulo=titulo, valida=valida)
    if operacion=="Modificar":
       sql = "update cruce_documentos_erp set tipo_cr = '" +  tipo_cr + "'" + "," + " id_cr = " +  id_cr + "," + " tipo_db = '" +  tipo_db + "'" + "," + " id_db = " +  id_db + "," + " fecha = '" +  fecha + "'" + "," + " valor = " +  valor + "," + " retencion = " +  retencion + "," + " rete_iva = " +  rete_iva + "," + " rete_ica = " +  rete_ica + "," + " ajuste = " +  ajuste + "," + " observaciones = '" +  observaciones + "'"  + " where id_empresa = " +  str(session['id_empresa']) + " and  id = " +  id
       print("sql:", sql)
       cur = mysql.connection.cursor()
       cur.execute(sql)
       mysql.connection.commit()
    if operacion=="Eliminar":
       sql = "delete from  cruce_documentos_erp where id_empresa = " + str(session['id_empresa']) + " and  id = " + id
       print("sql:", sql)
       cur = mysql.connection.cursor()
       cur.execute(sql)
       mysql.connection.commit()
    print ("va para frm_cruce_documentos_erp_list")
    errores=""
    titulo="Registro cruce_documentos_erp"
    return redirect(url_for('frm_cruce_documentos_erp.frm_cruce_documentos_erp_primero'))
    
@frm_cruce_documentos_erp.route('/frm_cruce_documentos_erp_show/<ope>/<id_empresa>/<id>', methods=['GET'])
def frm_cruce_documentos_erp_show(ope, id_empresa, id): 
    print("Begin frm_cruce_documentos_erp_show(): ope=", ope)
    valida=""
    
    if ope== "M" or ope == "E":
       sql = "select * from cruce_documentos_erp where id_empresa = " + str(session['id_empresa']) + " and  id = " + id
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
    titulo="Registro cruce_documentos_erp: "+ operacion
    print("registro:", registro)
    errores=""
    return render_template('frm_cruce_documentos_erp_show.html', reg=registro, bloquea_campos=bloquea_campos, bloquea_claves=bloquea_claves, operacion=operacion, errores=errores, titulo=titulo, valida=valida)
@frm_cruce_documentos_erp.route('/frm_cruce_documentos_erp_primero', methods=['GET'])
def frm_cruce_documentos_erp_primero(): 
    print('Begin frm_cruce_documentos_erp_primero()...')
    if "user_id" not in session:
       return redirect(url_for('login'))
    global registros
    pos=0
    sql="SELECT count(*) as registros from cruce_documentos_erp where id_empresa = " + str(session['id_empresa'])
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchone()
    registros=tabla['registros']
    reg=25
    print("registros:",registros)
    #sql = 'SELECT * FROM cruce_documentos_erp limit ' + str(pos) + ', ' + str(reg)  
    sql = "SELECT * FROM cruce_documentos_erp WHERE id_empresa = " + str(session['id_empresa']) + ' limit ' + str(pos) + ', ' + str(reg)  
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchall()
    if len(tabla) >= 0:
       navega = 's'
       return render_template('frm_cruce_documentos_erp_list.html', orders=tabla, navega=navega)
    else:
       print('Error al listar cruce_documentos_erp')
       return render_template('error.html', errores='Error al listar canales. ', pos=pos)
def arma_filtro(filtro):
    print("Begin arma_filtro():...")
    fil = " and  ( id like '%" + filtro + "%'" 
    fil = fil + " or tipo_cr like '%" + filtro + "%'" 
    fil = fil + " or id_cr like '%" + filtro + "%'" 
    fil = fil + " or tipo_db like '%" + filtro + "%'" 
    fil = fil + " or id_db like '%" + filtro + "%'" 
    fil = fil + " or fecha like '%" + filtro + "%'" 
    fil = fil + " or valor like '%" + filtro + "%'" 
    fil = fil + " or retencion like '%" + filtro + "%'" 
    fil = fil + " or rete_iva like '%" + filtro + "%'" 
    fil = fil + " or rete_ica like '%" + filtro + "%'" 
    fil = fil + " or ajuste like '%" + filtro + "%'" 
    fil = fil + " or observaciones like '%" + filtro + "%'" 
    fil = fil + ")" 
    return fil
@frm_cruce_documentos_erp.route('/frm_cruce_documentos_erp_list', methods=['POST'])
def frm_cruce_documentos_erp_list(): 
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
       sql="SELECT count(*) as registros from cruce_documentos_erp WHERE id_empresa = " + str(session['id_empresa']) + " " + filtro
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
    sql = "SELECT * FROM cruce_documentos_erp WHERE id_empresa = " + str(session['id_empresa']) + " " + filtro + " limit " + str(pos) + ", " + str(reg)  
    print("sql:", sql)
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchall()
    if len(tabla) >= 0:
       navega = 's'
       return render_template('frm_cruce_documentos_erp_list.html', orders=tabla, navega=navega, fil=fil)
    else:
       print('Error al listar empresas')
       return render_template('error.html', errores='Error al listar canales. ', pos=pos, fil=fil)
