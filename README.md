# Practica-final Voluntaria


En esta práctica se trabajará sobre el proyecto CleanArchitecture que se ha venido trabajando a través del curso.

1.	El negocio de alquiler de autos quiere expandirse, asi que de ahora en adelante además de alquilar autos, también se encargará de alquilar “viviendas”.

2.	Necesita crear, siguiendo los principios de Domain Driven Design y utilizando object values como properties, una entidad que llamará “Vivienda”,  cuando se genere la tabla en la base de datos, esta tabla física deberá tener las siguientes columnas:
a.	id
b.	direccion_calle
c.	direccion_ciudad
d.	direccion_provincia
e.	direccion_departamento
f.	direccion_pais
g.	precio
h.	fecha_ultimo_alquiler

3.	La relación entre Vivienda y Alquiler deberá ser de uno a muchos, una vivienda puede ser alquilada muchas veces.

4.	Genere data de prueba para esta tabla Vivienda, inserte la data utilizando los métodos de Dapper, para esto dentro del archivo SeedDataExtensions.cs deberá crear un nuevo método static para la inserción de esta data.

Recuerde que el archivo SeedDataExtensions.cs se encuentra en:
src/CleanArchitecture/CleanArchitecture.Api/Extensions/SeedDataExtensions.cs

5.	Deberá crear un nuevo controller y un endpoint que devuelta toda la data de prueba de esta tabla “vivienda”.

