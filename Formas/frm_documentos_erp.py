from flask import Flask, render_template, request, redirect, url_for, Response, session, jsonify, Markup
import flask 
from flask_mysqldb import MySQL
from config import Config as cfg
frm_documentos_erp=flask.Blueprint('frm_documentos_erp', __name__)
app = Flask(__name__, template_folder="templates")
app.debug = True
app.secret_key = cfg.SECRET_KEY
mysql=MySQL(app)
registros=0
pos=0
fil=""
@frm_documentos_erp.route('/frm_documentos_erp_act/<operacion>', methods=['POST'])
def frm_documentos_erp_act(operacion): 
    print('Begin frm_documentos_erp_act():..')
    id_empresa=str(request.form['id_empresa'])
    tipo=str(request.form['tipo'])
    id=str(request.form['id'])
    id_bodega=str(request.form['id_bodega'])
    fecha=str(request.form['fecha'])
    vence=str(request.form['vence'])
    procesado=str(request.form['procesado'])
    id_cliente=str(request.form['id_cliente'])
    id_vendedor=str(request.form['id_vendedor'])
    valor_documento=str(request.form['valor_documento'])
    saldo=str(request.form['saldo'])
    descuento=str(request.form['descuento'])
    rete_iva=str(request.form['rete_iva'])
    rete_ica=str(request.form['rete_ica'])
    rete_fuente=str(request.form['rete_fuente'])
    id_canal=str(request.form['id_canal'])
    nro_documento_canal=str(request.form['nro_documento_canal'])
    condicion_pago=str(request.form['condicion_pago'])
    observaciones=str(request.form['observaciones'])
    estado_fe=str(request.form['estado_fe'])
    estado_despacho=str(request.form['estado_despacho'])
    if operacion=="Crear":
       sql = "insert into documentos_erp (id_empresa, tipo, id, id_bodega, fecha, vence, procesado, id_cliente, id_vendedor, valor_documento, saldo, descuento, rete_iva, rete_ica, rete_fuente, id_canal, nro_documento_canal, condicion_pago, observaciones, estado_fe, estado_despacho) values (" + str(session['id_empresa']) + ","  + "'" + tipo + "'" + ","  + "'" + id + "'" + ","  + "'" + id_bodega + "'" + ","  + "'" + fecha + "'" + ","  + "'" + vence + "'" + ","  + procesado + ","  + "'" + id_cliente + "'" + ","  + "'" + id_vendedor + "'" + ","  + valor_documento + ","  + saldo + ","  + descuento + ","  + rete_iva + ","  + rete_ica + ","  + rete_fuente + ","  + "'" + id_canal + "'" + ","  + "'" + nro_documento_canal + "'" + ","  + "'" + condicion_pago + "'" + ","  + "'" + observaciones + "'" + ","  + "'" + estado_fe + "'" + ","  + "'" + estado_despacho + "'" + ")"
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
          reg['tipo']=tipo
          reg['id']=id
          reg['id_bodega']=id_bodega
          reg['fecha']=fecha
          reg['vence']=vence
          reg['procesado']=procesado
          reg['id_cliente']=id_cliente
          reg['id_vendedor']=id_vendedor
          reg['valor_documento']=valor_documento
          reg['saldo']=saldo
          reg['descuento']=descuento
          reg['rete_iva']=rete_iva
          reg['rete_ica']=rete_ica
          reg['rete_fuente']=rete_fuente
          reg['id_canal']=id_canal
          reg['nro_documento_canal']=nro_documento_canal
          reg['condicion_pago']=condicion_pago
          reg['observaciones']=observaciones
          reg['estado_fe']=estado_fe
          reg['estado_despacho']=estado_despacho
          titulo="Registro documentos_erp: arregle las inconsistencias"
          valida=""
          return render_template('frm_documentos_erp_show.html', reg=reg, bloquea_campos=bloquea_campos, bloquea_claves=bloquea_claves, operacion=operacion, errores=errores, titulo=titulo, valida=valida)
    if operacion=="Modificar":
       sql = "update documentos_erp set id_bodega = '" +  id_bodega + "'" + "," + " fecha = '" +  fecha + "'" + "," + " vence = '" +  vence + "'" + "," + " procesado = " +  procesado + "," + " id_cliente = '" +  id_cliente + "'" + "," + " id_vendedor = '" +  id_vendedor + "'" + "," + " valor_documento = " +  valor_documento + "," + " saldo = " +  saldo + "," + " descuento = " +  descuento + "," + " rete_iva = " +  rete_iva + "," + " rete_ica = " +  rete_ica + "," + " rete_fuente = " +  rete_fuente + "," + " id_canal = '" +  id_canal + "'" + "," + " nro_documento_canal = '" +  nro_documento_canal + "'" + "," + " condicion_pago = '" +  condicion_pago + "'" + "," + " observaciones = '" +  observaciones + "'" + "," + " estado_fe = '" +  estado_fe + "'" + "," + " estado_despacho = '" +  estado_despacho + "'"  + " where id_empresa = " +  str(session['id_empresa']) + " and  tipo = '" +  tipo + "'" + " and  id = '" +  id + "'"
       print("sql:", sql)
       cur = mysql.connection.cursor()
       cur.execute(sql)
       mysql.connection.commit()
    if operacion=="Eliminar":
       sql = "delete from  documentos_erp where id_empresa = " + str(session['id_empresa']) + " and  tipo = '" + tipo + "'" + " and  id = '" + id + "'"
       print("sql:", sql)
       cur = mysql.connection.cursor()
       cur.execute(sql)
       mysql.connection.commit()
    print ("va para frm_documentos_erp_list")
    errores=""
    titulo="Registro documentos_erp"
    return redirect(url_for('frm_documentos_erp.frm_documentos_erp_primero'))
    
@frm_documentos_erp.route('/frm_documentos_erp_show/<ope>/<id_empresa>/<tipo>/<id>', methods=['GET'])
def frm_documentos_erp_show(ope, id_empresa, tipo, id): 
    print("Begin frm_documentos_erp_show(): ope=", ope)
    valida=""
    
    if ope== "M" or ope == "E":
       sql = "select * from documentos_erp where id_empresa = " + str(session['id_empresa']) + " and  tipo = '" + tipo+ "'" + " and  id = '" + id+ "'"
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
    titulo="Registro documentos_erp: "+ operacion
    print("registro:", registro)
    errores=""
    return render_template('frm_documentos_erp_show.html', reg=registro, bloquea_campos=bloquea_campos, bloquea_claves=bloquea_claves, operacion=operacion, errores=errores, titulo=titulo, valida=valida)
@frm_documentos_erp.route('/frm_documentos_erp_primero', methods=['GET'])
def frm_documentos_erp_primero(): 
    print('Begin frm_documentos_erp_primero()...')
    if "user_id" not in session:
       return redirect(url_for('login'))
    global registros
    pos=0
    sql="SELECT count(*) as registros from documentos_erp where id_empresa = " + str(session['id_empresa'])
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchone()
    registros=tabla['registros']
    reg=25
    print("registros:",registros)
    #sql = 'SELECT * FROM documentos_erp limit ' + str(pos) + ', ' + str(reg)  
    sql = "SELECT * FROM documentos_erp WHERE id_empresa = " + str(session['id_empresa']) + ' limit ' + str(pos) + ', ' + str(reg)  
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchall()
    if len(tabla) >= 0:
       navega = 's'
       return render_template('frm_documentos_erp_list.html', orders=tabla, navega=navega)
    else:
       print('Error al listar documentos_erp')
       return render_template('error.html', errores='Error al listar canales. ', pos=pos)
def arma_filtro(filtro):
    print("Begin arma_filtro():...")
    fil = " and  ( tipo like '%" + filtro + "%'" 
    fil = fil + " or id like '%" + filtro + "%'" 
    fil = fil + " or id_bodega like '%" + filtro + "%'" 
    fil = fil + " or fecha like '%" + filtro + "%'" 
    fil = fil + " or vence like '%" + filtro + "%'" 
    fil = fil + " or procesado like '%" + filtro + "%'" 
    fil = fil + " or id_cliente like '%" + filtro + "%'" 
    fil = fil + " or id_vendedor like '%" + filtro + "%'" 
    fil = fil + " or valor_documento like '%" + filtro + "%'" 
    fil = fil + " or saldo like '%" + filtro + "%'" 
    fil = fil + " or descuento like '%" + filtro + "%'" 
    fil = fil + " or rete_iva like '%" + filtro + "%'" 
    fil = fil + " or rete_ica like '%" + filtro + "%'" 
    fil = fil + " or rete_fuente like '%" + filtro + "%'" 
    fil = fil + " or id_canal like '%" + filtro + "%'" 
    fil = fil + " or nro_documento_canal like '%" + filtro + "%'" 
    fil = fil + " or condicion_pago like '%" + filtro + "%'" 
    fil = fil + " or observaciones like '%" + filtro + "%'" 
    fil = fil + " or estado_fe like '%" + filtro + "%'" 
    fil = fil + " or estado_despacho like '%" + filtro + "%'" 
    fil = fil + ")" 
    return fil
@frm_documentos_erp.route('/frm_documentos_erp_list', methods=['POST'])
def frm_documentos_erp_list(): 
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
       sql="SELECT count(*) as registros from documentos_erp WHERE id_empresa = " + str(session['id_empresa']) + " " + filtro
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
    sql = "SELECT * FROM documentos_erp WHERE id_empresa = " + str(session['id_empresa']) + " " + filtro + " limit " + str(pos) + ", " + str(reg)  
    print("sql:", sql)
    cur = mysql.connection.cursor()
    cur.execute(sql)
    tabla = cur.fetchall()
    if len(tabla) >= 0:
       navega = 's'
       return render_template('frm_documentos_erp_list.html', orders=tabla, navega=navega, fil=fil)
    else:
       print('Error al listar empresas')
       return render_template('error.html', errores='Error al listar canales. ', pos=pos, fil=fil)
