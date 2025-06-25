pasos que se hicieron:
FULLSTACK CON ANGULAR 

hicismos una base de datos en MySQL server 
e hicimos una nueva api web en c#
borramos el weatherforecast e instalamos las dependencias

vamos a program y agregamos el nigger... swagger

ahora apartir de la BD nos genere los modelos

se hace con un comando en el administrador de paquetes:
Scaffold-DbContext "Server=DESKTOP-URLB235; Initial Catalog=BDTareas_902; user id=sa; password=root;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models

modificarlo a nuestra manera
en mi caso quedaría 
 Scaffold-DbContext "Server=CESAR\MSSQLSERVER01; Initial Catalog=BDTareas_904;; user id=sa; password=root;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models

se generaron diferentes archivos en model y un context

en el método de context borramos el método de la cadena de conexión el método OnConfiguring

hacemos la cadena de conexión 

en program cs configuramos la conexión de BD 

hacemos un tareasController en el controller y lo hacemos 


despues probramos con /swagger/index.html


despues hacemos una politica CORS en el Programs
