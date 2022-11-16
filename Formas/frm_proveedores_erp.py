from flask import Flask, render_template, request, redirect, url_for, Response, session, jsonify, Markup
import flask 
from flask_mysqldb import MySQL
from config import Config as cfg
frm_proveedores_erp=flask.Blueprint('frm_proveedores_erp', __name__)
app = Flask(__name__, template_folder="templates")
app.debug = True
app.secret_key = cfg.SECRET_KEY
mysql=MySQL(app)
registros=0
pos=0
fil=""
@frm_proveedores_erp.route('/frm_proveedores_erp_act/<operacion>', methods=['POST'])
def frm_proveedores_erp_act(operacion): 
    print('Begin frm_proveedores_erp_act():..')
    id_empresa=str(request.form['id_empresa'])
    id=str(request.form['id'])
    tipo_documento=str(request.form['tipo_documento'])
    id_documento=str(request.form['id_documento'])
    dv=str(request.form['dv'])
    nombre=str(request.form['nombre'])
    direccion1=str(request.form['direccion1'])
    direccion2=str(request.form['direccion2'])
    direccion3=str(request.form['direccion3'])
    id_municipio=str(request.form['id_municipio'])
    telefono=str(request.form['telefono'])
    celular=str(request.form['celular'])
    if request.form.get('retiene_ival'):
       retiene_ival='1'
    else:
       retiene_ival='0'
    if request.form.get('retiene_ica'):
       retiene_ica='1'
    else:
       retiene_ica='0'
    if request.form.get('retiene_fuente'):
       retiene_fuente='1'
    else:
       retiene_fuente='0'
    observaciones=str(request.form['observaciones'])
    if operacion=="Crear":
       sql = "insert into proveedores_erp (id_empresa, id, tipo_documento, id_documento, dv, nombre, direccion1, direccion2, direccion3, id_municipio, telefono, celular, retiene_ival, retiene_ica, retiene_fuente, observaciones) values (" + str(session['id_empresa']) + ","  + id + ","  + "'" + tipo_documento + "'" + ","  + id_documento + ","  + dv + ","  + "'" + nombre + "'" + ","  + "'" + direccion1 + "'" + ","  + "'" + direccion2 + "'" + ","  + "'" + direccion3 + "'" + ","  + "'" + id_municipio + "'" + ","  + "'" + telefono + "'" + ","  + "'" + celular + "'" + ","  + retiene_ival + ","  + retiene_ica + ","  + retiene_fuente + ","  + "'" + observaciones + "'" + ")"
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
          reg['tipo_documento']=tipo_documento
          reg['id_documento']=id_documento
          reg['dv']=dv
          reg['nombre']=nombre
          reg['direccion1']=direccion1
          reg['direccion2']=direccion2
          reg['direccion3']=direccion3
          reg['id_municipio']=id_municipio
          reg['telefono']=telefono
          reg['celular']=celular
          reg['retiene_ival']=retiene_ival
          reg['retiene_ica']=retiene_ica
          reg['retiene_fuente']=retiene_fuente
          reg['observaciones']=observaciones
          titulo="Registro proveedores_erp: arregle las inconsistencias"
          valida=""
          return render_template('frm_proveedores_erp_show.html', reg=reg, bloquea_campos=bloquea_campos, bloquea_claves=bloquea_claves, operacion=operacion, errores=errores, titulo=titulo, valida=valida)
    if operacion=="Modificar":
       sql = "update proveedores_erp set tipo_documento = '" +  tipo_documento + "'" + "," + " id_documento = " +  id_documento + "," + " dv = " +  dv + "," + " nombre = '" +  nombre + "'" + "," + " direccion1 = '" +  direccion1 + "'" + "," + " direccion2 = '" +  direccion2 + "'" + "," + " direccion3 = '" +  direccion3 + "'" + "," + " id_municipio = '" +  id_municipio + "'" + "," + " telefono = '" +  telefono + "'" + "," + " celular = '" +  celular + "'" + "," + " retiene_ival = " + retiene_ival + "," + " retiene_ica = " + retiene_ica + "," + " retiene_fuente = " + retiene_fuente + "," + " observaciones = '" +  observaciones + "'"  + " where id_empresa = " +  str(session['id_empresa']) + " and  id = " +  id
       print("sql:", sql)
       cur = mysql.connection.cursor()
       cur.execute(sql)
       mysql.connection.commit()
    if operacion=="Eliminar":
       sql = "delete from  proveedores_erp where id_empresa = " + str(session['id_empresa']) + " and  id = " + id
       print("sql:", sql)
       cur = mysql.connection.cursor()
       cur.execute(sql)
       mysql.connection.commit()
    print ("va para frm_proveedores_erp_list")
    errores=""
    titulo="Registro proveedores_erp"
    return redirect(url_for('frm_proveedores_erp.frm_proveedores_erp_primero'))
    
@frm_proveedores_erp.route('/frm_proveedores_erp_show/<ope>/<id_empresa>/<id>', methods=['GET'])
def frm_proveedores_erp_show(ope, id_empresa, id): 
    print("Begin frm_proveedores_erp_show(): ope=", ope)
    valida=""
    
    if ope== "M" or ope == "E":
       sql = "select * from proveedores_erp where id_empresa = " + str(session['id_empresa']) + " and  id = " + id
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
       registro['retiene_ival']=0
       registro['retiene_ica']=0
       registro['retiene_fuente']=0
       registro['id_empresa']=session['id_empresa']
       operacion="Crear"
    titulo="Registro proveedores_erp: "+ operacion
    print("registro:", registro)
    errores=""
    return render_template('frm_proveedores_erp_show.html', reg=registro, bloquea_campos=bloquea_campos, bloquea_claves=bloquea_claves, operacion=operacion, errores=errores, titulo=titulo, valida=valida)
@frm_proveedores_erp.route('/frm_proveedores_erp_primero', methods=['GET'])
def frm_proveedores_erp_primero(): 
    print('Begin frm_proveedores_erp_primero()...')
    if "user_id" not in session:
       return redirect(url_for('login'))
    global registros
    pos=0
    sql="SELECT count(*) as registros from proveedores_erp where id_empresa = " + str(session['id_empresa'])
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchone()
    registros=tabla['registros']
    reg=25
    print("registros:",registros)
    #sql = 'SELECT * FROM proveedores_erp limit ' + str(pos) + ', ' + str(reg)  
    sql = "SELECT * FROM proveedores_erp WHERE id_empresa = " + str(session['id_empresa']) + ' limit ' + str(pos) + ', ' + str(reg)  
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchall()
    if len(tabla) >= 0:
       navega = 's'
       return render_template('frm_proveedores_erp_list.html', orders=tabla, navega=navega)
    else:
       print('Error al listar proveedores_erp')
       return render_template('error.html', errores='Error al listar canales. ', pos=pos)
def arma_filtro(filtro):
    print("Begin arma_filtro():...")
    fil = " and  ( id like '%" + filtro + "%'" 
    fil = fil + " or tipo_documento like '%" + filtro + "%'" 
    fil = fil + " or id_documento like '%" + filtro + "%'" 
    fil = fil + " or dv like '%" + filtro + "%'" 
    fil = fil + " or nombre like '%" + filtro + "%'" 
    fil = fil + " or direccion1 like '%" + filtro + "%'" 
    fil = fil + " or direccion2 like '%" + filtro + "%'" 
    fil = fil + " or direccion3 like '%" + filtro + "%'" 
    fil = fil + " or id_municipio like '%" + filtro + "%'" 
    fil = fil + " or telefono like '%" + filtro + "%'" 
    fil = fil + " or celular like '%" + filtro + "%'" 
    fil = fil + " or retiene_ival like '%" + filtro + "%'" 
    fil = fil + " or retiene_ica like '%" + filtro + "%'" 
    fil = fil + " or retiene_fuente like '%" + filtro + "%'" 
    fil = fil + " or observaciones like '%" + filtro + "%'" 
    fil = fil + ")" 
    return fil
@frm_proveedores_erp.route('/frm_proveedores_erp_list', methods=['POST'])
def frm_proveedores_erp_list(): 
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
       sql="SELECT count(*) as registros from proveedores_erp WHERE id_empresa = " + str(session['id_empresa']) + " " + filtro
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
    sql = "SELECT * FROM proveedores_erp WHERE id_empresa = " + str(session['id_empresa']) + " " + filtro + " limit " + str(pos) + ", " + str(reg)  
    print("sql:", sql)
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchall()
    if len(tabla) >= 0:
       navega = 's'
       return render_template('frm_proveedores_erp_list.html', orders=tabla, navega=navega, fil=fil)
    else:
       print('Error al listar empresas')
       return render_template('error.html', errores='Error al listar canales. ', pos=pos, fil=fil)
