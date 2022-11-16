from flask import Flask, render_template, request, redirect, url_for, Response, session, jsonify, Markup
import flask 
from flask_mysqldb import MySQL
from config import Config as cfg
frm_tablas=flask.Blueprint('frm_tablas', __name__)
app = Flask(__name__, template_folder="templates")
app.debug = True
app.secret_key = cfg.SECRET_KEY
mysql=MySQL(app)
registros=0
pos=0
fil=""
@frm_tablas.route('/frm_tablas_act/<operacion>', methods=['POST'])
def frm_tablas_act(operacion): 
    print('Begin frm_tablas_act():..')
    tabla=str(request.form['tabla'])
    orden=str(request.form['orden'])
    campo=str(request.form['campo'])
    clave=str(request.form['clave'])
    tipo=str(request.form['tipo'])
    tamano=str(request.form['tamano'])
    valida=str(request.form['valida'])
    tabla_combo=str(request.form['tabla_combo'])
    clave_combo=str(request.form['clave_combo'])
    muestra_combo=str(request.form['muestra_combo'])
    formato=str(request.form['formato'])
    enteros=str(request.form['enteros'])
    decimales=str(request.form['decimales'])
    muestra=str(request.form['muestra'])
    descripcion=str(request.form['descripcion'])
    label=str(request.form['label'])
    minimo=str(request.form['minimo'])
    maximo=str(request.form['maximo'])
    if operacion=="Crear":
       sql = "insert into tablas (tabla, orden, campo, clave, tipo, tamano, valida, tabla_combo, clave_combo, muestra_combo, formato, enteros, decimales, muestra, descripcion, label, minimo, maximo) values (" + "'" + tabla + "'" + ","  + orden + ","  + "'" + campo + "'" + ","  + "'" + clave + "'" + ","  + "'" + tipo + "'" + ","  + tamano + ","  + "'" + valida + "'" + ","  + "'" + tabla_combo + "'" + ","  + "'" + clave_combo + "'" + ","  + "'" + muestra_combo + "'" + ","  + "'" + formato + "'" + ","  + "'" + enteros + "'" + ","  + "'" + decimales + "'" + ","  + "'" + muestra + "'" + ","  + "'" + descripcion + "'" + ","  + "'" + label + "'" + ","  + "'" + minimo + "'" + ","  + "'" + maximo + "'" + ")"
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
          reg['tabla']=tabla
          reg['orden']=orden
          reg['campo']=campo
          reg['clave']=clave
          reg['tipo']=tipo
          reg['tamano']=tamano
          reg['valida']=valida
          reg['tabla_combo']=tabla_combo
          reg['clave_combo']=clave_combo
          reg['muestra_combo']=muestra_combo
          reg['formato']=formato
          reg['enteros']=enteros
          reg['decimales']=decimales
          reg['muestra']=muestra
          reg['descripcion']=descripcion
          reg['label']=label
          reg['minimo']=minimo
          reg['maximo']=maximo
          titulo="Registro tablas: arregle las inconsistencias"
          valida=""
          return render_template('frm_tablas_show.html', reg=reg, bloquea_campos=bloquea_campos, bloquea_claves=bloquea_claves, operacion=operacion, errores=errores, titulo=titulo, valida=valida)
    if operacion=="Modificar":
       sql = "update tablas set campo = '" +  campo + "'" + "," + " clave = '" +  clave + "'" + "," + " tipo = '" +  tipo + "'" + "," + " tamano = " +  tamano + "," + " valida = '" +  valida + "'" + "," + " tabla_combo = '" +  tabla_combo + "'" + "," + " clave_combo = '" +  clave_combo + "'" + "," + " muestra_combo = '" +  muestra_combo + "'" + "," + " formato = '" +  formato + "'" + "," + " enteros = '" +  enteros + "'" + "," + " decimales = '" +  decimales + "'" + "," + " muestra = '" +  muestra + "'" + "," + " descripcion = '" +  descripcion + "'" + "," + " label = '" +  label + "'" + "," + " minimo = '" +  minimo + "'" + "," + " maximo = '" +  maximo + "'"  + " where tabla = '" +  tabla + "'" + " and  orden = " +  orden
       print("sql:", sql)
       cur = mysql.connection.cursor()
       cur.execute(sql)
       mysql.connection.commit()
    if operacion=="Eliminar":
       sql = "delete from  tablas where tabla = '" + tabla + "'" + " and  orden = " + orden
       print("sql:", sql)
       cur = mysql.connection.cursor()
       cur.execute(sql)
       mysql.connection.commit()
    print ("va para frm_tablas_list")
    errores=""
    titulo="Registro tablas"
    return redirect(url_for('frm_tablas.frm_tablas_primero'))
    
@frm_tablas.route('/frm_tablas_show/<ope>/<tabla>/<orden>', methods=['GET'])
def frm_tablas_show(ope, tabla, orden): 
    print("Begin frm_tablas_show(): ope=", ope)
    valida=""
    
    if ope== "M" or ope == "E":
       sql = "select * from tablas where tabla = '" + tabla+ "'" + " and  orden = " + orden
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
    titulo="Registro tablas: "+ operacion
    print("registro:", registro)
    errores=""
    return render_template('frm_tablas_show.html', reg=registro, bloquea_campos=bloquea_campos, bloquea_claves=bloquea_claves, operacion=operacion, errores=errores, titulo=titulo, valida=valida)
@frm_tablas.route('/frm_tablas_primero', methods=['GET'])
def frm_tablas_primero(): 
    print('Begin frm_tablas_primero()...')
    if "user_id" not in session:
       return redirect(url_for('login'))
    global registros
    pos=0
    sql="SELECT count(*) as registros from tablas where id_empresa = " + str(session['id_empresa'])
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchone()
    registros=tabla['registros']
    reg=25
    print("registros:",registros)
    #sql = 'SELECT * FROM tablas limit ' + str(pos) + ', ' + str(reg)  
    sql = "SELECT * FROM tablas WHERE id_empresa = " + str(session['id_empresa']) + ' limit ' + str(pos) + ', ' + str(reg)  
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchall()
    if len(tabla) >= 0:
       navega = 's'
       return render_template('frm_tablas_list.html', orders=tabla, navega=navega)
    else:
       print('Error al listar tablas')
       return render_template('error.html', errores='Error al listar canales. ', pos=pos)
def arma_filtro(filtro):
    print("Begin arma_filtro():...")
    fil = " and  ( tabla like '%" + filtro + "%'" 
    fil = fil + " or orden like '%" + filtro + "%'" 
    fil = fil + " or campo like '%" + filtro + "%'" 
    fil = fil + " or clave like '%" + filtro + "%'" 
    fil = fil + " or tipo like '%" + filtro + "%'" 
    fil = fil + " or tamano like '%" + filtro + "%'" 
    fil = fil + " or valida like '%" + filtro + "%'" 
    fil = fil + " or tabla_combo like '%" + filtro + "%'" 
    fil = fil + " or clave_combo like '%" + filtro + "%'" 
    fil = fil + " or muestra_combo like '%" + filtro + "%'" 
    fil = fil + " or formato like '%" + filtro + "%'" 
    fil = fil + " or enteros like '%" + filtro + "%'" 
    fil = fil + " or decimales like '%" + filtro + "%'" 
    fil = fil + " or muestra like '%" + filtro + "%'" 
    fil = fil + " or descripcion like '%" + filtro + "%'" 
    fil = fil + " or label like '%" + filtro + "%'" 
    fil = fil + " or minimo like '%" + filtro + "%'" 
    fil = fil + " or maximo like '%" + filtro + "%'" 
    fil = fil + ")" 
    return fil
@frm_tablas.route('/frm_tablas_list', methods=['POST'])
def frm_tablas_list(): 
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
       sql="SELECT count(*) as registros from tablas WHERE id_empresa = " + str(session['id_empresa']) + " " + filtro
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
    sql = "SELECT * FROM tablas WHERE id_empresa = " + str(session['id_empresa']) + " " + filtro + " limit " + str(pos) + ", " + str(reg)  
    print("sql:", sql)
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchall()
    if len(tabla) >= 0:
       navega = 's'
       return render_template('frm_tablas_list.html', orders=tabla, navega=navega, fil=fil)
    else:
       print('Error al listar empresas')
       return render_template('error.html', errores='Error al listar canales. ', pos=pos, fil=fil)
