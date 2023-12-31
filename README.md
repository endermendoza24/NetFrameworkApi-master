# Proyecto ApiFramework 4.8

## EntityStore.

En este archivo es donde se guardan en memoria los datos de la API, este mismo archivo sirve para conectarlo con todas las entidades.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Application.Endpoint
{
    public class EntityStore<T> where T : class
    {
        // Lista privada para almacenar las entidades
        private static List<T> _entidades = new List<T>();
        
        // Función para obtener el ID de una entidad (se pasa como argumento)
        private Func<T, int> _obtenerIdFunc;

        // Variable para asignar IDs automáticamente
        private static int _siguienteId = 1;

        // Constructor que toma una función para obtener el ID
        public EntityStore(Func<T, int> obtenerIdFunc)
        {
            _obtenerIdFunc = obtenerIdFunc;
            // Inicializa _siguienteId solo si es igual a cero
            if (_siguienteId == 0)
            {
                _siguienteId = _entidades.Count + 1;
            }
        }

        // Constructor predeterminado sin argumentos
        public EntityStore()
        {
        }

        // Método para obtener todas las entidades almacenadas
        public List<T> ObtenerTodo()
        {
            return _entidades;
        }

        // Método para agregar una entidad a la lista
        public void Agregar(T entidad)
        {
            int id = _siguienteId++;
            // Asigna automáticamente un ID a la entidad
            typeof(T).GetProperty("ID")?.SetValue(entidad, id);
            _entidades.Add(entidad);
        }

        // Método para obtener una entidad por su ID
        public T ObtenerPorId(int id)
        {
            return _entidades.FirstOrDefault(e => _obtenerIdFunc(e) == id);
        }

        // Método para eliminar una entidad por su ID
        public void Eliminar(int id)
        {
            T entidad = _entidades.FirstOrDefault(e => _obtenerIdFunc(e) == id);
            if (entidad != null)
            {
                _entidades.Remove(entidad);
            }
        }

        // Método para actualizar una entidad por su ID con nuevos datos
        public void Actualizar(int id, T entidadActualizada)
        {
            T entidad = _entidades.FirstOrDefault(e => _obtenerIdFunc(e) == id);
            if (entidad != null)
            {
                // Copia los valores de las propiedades relevantes de entidadActualizada a entidad
                PropertyInfo[] propiedades = typeof(T).GetProperties();
                foreach (PropertyInfo property in propiedades)
                {
                    if (property.Name != "ID") // Evita modificar la property "ID"
                    {
                        object nuevoValor = property.GetValue(entidadActualizada);
                        if (nuevoValor != null)
                        {
                            property.SetValue(entidad, nuevoValor);
                        }
                    }
                }
            }
        }
    }
}
```

En resumen, esta clase **`EntityStore`** se utiliza para gestionar una lista de entidades genéricas (objetos) de manera eficiente. Puede agregar, actualizar, eliminar y obtener entidades por su ID, y proporciona flexibilidad al permitir que se especifique una función para obtener el ID de las entidades. También asigna automáticamente IDs a las entidades si no se proporcionan.

---

1. **`private static List<T> _entidades = new List<T>();`**
    - Esta línea declara una lista privada llamada **`_entidades`** que almacenará las entidades de tipo **`T`**. La lista es estática, lo que significa que es compartida por todas las instancias de la clase.
2. **`private Func<T, int> _obtenerIdFunc;`**
    - Aquí se declara una variable **`_obtenerIdFunc`** que es una función que toma un objeto de tipo **`T`** y devuelve un entero. Esta función se utiliza para obtener el ID de una entidad.
3. **`private static int _siguienteId = 1;`**
    - Esta línea declara una variable **`_siguienteId`** que se utiliza para asignar automáticamente IDs a las entidades. Comienza en 1 y se incrementa cada vez que se agrega una nueva entidad.
4. **`public EntityStore(Func<T, int> obtenerIdFunc)`**
    - Este es el constructor de la clase. Recibe una función como argumento para obtener IDs y la almacena en **`_obtenerIdFunc`**.
5. **`public List<T> ObtenerTodo()`**
    - Este método devuelve la lista de todas las entidades almacenadas en **`_entidades`**.
6. **`public void Agregar(T entidad)`**
    - Este método se utiliza para agregar una entidad a la lista **`_entidades`**. Asigna automáticamente un ID a la entidad antes de agregarla.
7. **`public T ObtenerPorId(int id)`**
    - Este método busca una entidad por su ID y la devuelve. Utiliza la función **`_obtenerIdFunc`** para realizar la búsqueda.
8. **`public void Eliminar(int id)`**
    - Este método elimina una entidad de la lista **`_entidades`** según su ID.
9. **`public void Actualizar(int id, T entidadActualizada)`**
    - Este método actualiza una entidad existente en la lista **`_entidades`**. Copia los valores de las propiedades relevantes de **`entidadActualizada`** a la entidad existente, evitando modificar la propiedad "ID".

En resumen, esta clase **`EntityStore`** proporciona una forma genérica de administrar y realizar operaciones en una lista de objetos de cualquier tipo que cumpla con la restricción **`where T : class`**. Puede asignar automáticamente IDs a las entidades y permite realizar operaciones comunes como agregar, obtener, actualizar y eliminar entidades de la lista. Además, es configurable para obtener IDs personalizados utilizando una función externa.

---

---

## Explicación de controlador, en este caso ProductoController (Pero aplica a cualquier controlador)

Este es el código

```csharp
using Domain.Endpoint.Entities;  // Importa las entidades relacionadas con los productos
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        private EntityStore<Producto> _productoStore;  // Instancia de EntityStore para gestionar productos

        public ProductoController()
        {
            // Constructor del controlador, inicializa _productoStore con una función para obtener IDs de productos
            _productoStore = new EntityStore<Producto>(p => p.ID);
        }

        [HttpGet]
        public IHttpActionResult ObtenerProductos()
        {
            try
            {
                List<Producto> productos = _productoStore.ObtenerTodo();  // Obtiene todos los productos
                return Ok(productos);  // Devuelve una respuesta HTTP 200 OK con la lista de productos
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);  // Si ocurre un error, devuelve una respuesta HTTP 500 Internal Server Error
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerProducto(int id)
        {
            try
            {
                Producto producto = _productoStore.ObtenerPorId(id);  // Obtiene un producto por su ID
                if (producto == null)
                    return NotFound();  // Si el producto no se encuentra, devuelve una respuesta HTTP 404 Not Found

                return Ok(producto);  // Si se encuentra, devuelve una respuesta HTTP 200 OK con el producto
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);  // Si ocurre un error, devuelve una respuesta HTTP 500 Internal Server Error
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarProducto([FromBody] Producto nuevoProducto)
        {
            try
            {
                _productoStore.Agregar(nuevoProducto);  // Agrega un nuevo producto
                List<Producto> productos = _productoStore.ObtenerTodo();  // Obtiene todos los productos actualizados
                return Ok(productos);  // Devuelve una respuesta HTTP 200 OK con la lista actualizada de productos
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);  // Si ocurre un error, devuelve una respuesta HTTP 500 Internal Server Error
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarProducto(int id, [FromBody] Producto productoActualizado)
        {
            try
            {
                _productoStore.Actualizar(id, productoActualizado);  // Actualiza un producto existente por su ID
                List<Producto> productos = _productoStore.ObtenerTodo();  // Obtiene todos los productos actualizados
                return Ok(productos);  // Devuelve una respuesta HTTP 200 OK con la lista actualizada de productos
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);  // Si ocurre un error, devuelve una respuesta HTTP 500 Internal Server Error
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarProducto(int id)
        {
            try
            {
                _productoStore.Eliminar(id);  // Elimina un producto por su ID
                List<Producto> productos = _productoStore.ObtenerTodo();  // Obtiene todos los productos actualizados
                return Ok(productos);  // Devuelve una respuesta HTTP 200 OK con la lista actualizada de productos
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);  // Si ocurre un error, devuelve una respuesta HTTP 500 Internal Server Error
            }
        }
    }
}
```

Explicación

- **`private EntityStore<Producto> _productoStore;`**: Esta línea declara una instancia de la clase **`EntityStore`** específicamente para gestionar entidades de tipo **`Producto`**. Esta instancia se utilizará para llevar un registro de los productos y realizar operaciones en ellos.
- **`public ProductoController()`**: Este es el constructor del controlador. Se ejecuta cuando se crea una instancia de **`ProductoController`** y se utiliza para inicializar la instancia **`_productoStore`**. En este caso, se configura **`_productoStore`** para utilizar la propiedad **`ID`** de la entidad **`Producto`** como identificador.
- **`[HttpGet]`**, **`[HttpPost]`**, **`[HttpPut]`**, **`[HttpDelete]`**: Estos son atributos que marcan los métodos del controlador como manejadores de solicitudes HTTP GET, POST, PUT y DELETE, respectivamente. Cada uno de estos métodos corresponde a una operación CRUD específica en productos.
- **`public IHttpActionResult ObtenerProductos()`**: Este método maneja las solicitudes HTTP GET para obtener todos los productos. Dentro del bloque **`try`**, se llama a **`_productoStore.ObtenerTodo()`** para obtener la lista de productos y luego se devuelve una respuesta HTTP 200 OK con la lista de productos utilizando **`return Ok(productos)`**. Si ocurre un error, se captura en el bloque **`catch`** y se devuelve una respuesta HTTP 500 Internal Server Error.
- Los otros métodos en el controlador (**`ObtenerProducto`**, **`AgregarProducto`**, **`ActualizarProducto`**, **`EliminarProducto`**) siguen un patrón similar, donde cada uno realiza una operación específica en productos y responde de manera apropiada según el resultado o cualquier error que pueda ocurrir.

En resumen, este controlador se encarga de gestionar operaciones CRUD en productos y utiliza la instancia de **`EntityStore`** para realizar estas operaciones y devolver respuestas HTTP adecuadas según el resultado.

---

---

## Archivo de entidad, en este caso entidad Producto (Aplica a todas las entidades).

Código Producto.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Producto
    {
        // Propiedades de la clase Producto
        public int ID { get; set; }  // Identificador único del producto
        public string descripcion { get; set; }  // Descripción del producto
        public string NOMBRE_PRODUCTO { get; set; }  // Nombre del producto
        public int ID_COLOR { get; set; }  // Identificador del color del producto
        public int EXISTENCIA { get; set; }  // Cantidad en existencia del producto
        public int ID_MARCA { get; set; }  // Identificador de la marca del producto
        public int ID_MATERIAL { get; set; }  // Identificador del material del producto
        public int ID_CATEGORIA { get; set; }  // Identificador de la categoría del producto
        public int ID_BODEGA { get; set; }  // Identificador de la bodega donde se almacena el producto
        public int ID_TALLA { get; set; }  // Identificador de la talla del producto
        public bool Estado { get; set; }  // Estado del producto (activo o inactivo)
    }
}
```

Explicación (Esta es la tabla que ustedes nos pasaron, Entidades en pocas palabras son las tablas de catálogos que ustedes tienen en la base que nos pasaron,en la rúbrica solo sale que hagan los catálogos). 

![Untitled](Proyecto%20ApiFramework%204%208%2006ccd0dd308f4515a027b23cb8249a12/Untitled.png)

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Producto
    {
        // Propiedades de la clase Producto
        public int ID { get; set; }  // Identificador único del producto
        public string descripcion { get; set; }  // Descripción del producto
        public string NOMBRE_PRODUCTO { get; set; }  // Nombre del producto
        public int ID_COLOR { get; set; }  // Identificador del color del producto
        public int EXISTENCIA { get; set; }  // Cantidad en existencia del producto
        public int ID_MARCA { get; set; }  // Identificador de la marca del producto
        public int ID_MATERIAL { get; set; }  // Identificador del material del producto
        public int ID_CATEGORIA { get; set; }  // Identificador de la categoría del producto
        public int ID_BODEGA { get; set; }  // Identificador de la bodega donde se almacena el producto
        public int ID_TALLA { get; set; }  // Identificador de la talla del producto
        public bool Estado { get; set; }  // Estado del producto (activo o inactivo)
    }
}
```

Explicación

- Esta clase **`Producto`** define una entidad que representa un producto en un sistema. Tiene varias propiedades que almacenan información sobre el producto, como su ID único, descripción, nombre, color, existencia, marca, material, categoría, bodega, talla y estado.
- Cada propiedad tiene un modificador **`get; set;`**, lo que significa que se pueden obtener (leer) y establecer (escribir) sus valores desde fuera de la clase. Esto permite que las propiedades se utilicen para almacenar y recuperar información sobre un producto.
- Por ejemplo, **`public int ID { get; set; }`** es una propiedad que representa el identificador único del producto. Puede utilizarse para asignar un ID a un producto específico o para obtener el ID de un producto existente.
- Las propiedades de la clase **`Producto`** son públicas, lo que significa que se pueden acceder desde cualquier parte del código que tenga una instancia de un objeto **`Producto`**.

En resumen, esta clase **`Producto`** define la estructura de un objeto que representa un producto y proporciona propiedades para almacenar información relevante sobre ese producto, como su nombre, descripción, existencia, y otros atributos. Esta estructura es común en aplicaciones que gestionan inventarios o catálogos de productos.

---

---

---

## Resumen.

Los tres archivos que has proporcionado, que son **`EntityStore.cs`**, **`ProductoController.cs`**, y **`Producto.cs`**, se relacionan de la siguiente manera para funcionar como un conjunto en una aplicación:

1. **`Producto.cs` (Clase de Entidad):** Este archivo define la estructura de una entidad llamada **`Producto`**. Esta entidad representa un producto y tiene propiedades que almacenan información sobre el producto, como su ID, descripción, nombre, etc. Esta clase es una representación de cómo se almacena la información del producto en la base de datos o en memoria.
2. **`EntityStore.cs` (Clase de Almacenamiento Genérico):** **`EntityStore`** es una clase genérica que proporciona funcionalidad para el almacenamiento y la gestión de entidades genéricas. Puede trabajar con cualquier tipo de entidad que cumpla con la restricción **`where T : class`**. En este caso, se utiliza para gestionar objetos de tipo **`Producto`**, pero podría adaptarse para gestionar otros tipos de entidades también. Esta clase contiene métodos para agregar, obtener, actualizar y eliminar entidades, así como para mantener un registro de ellas.
3. **`ProductoController.cs` (Controlador de la API Web):** Este archivo contiene un controlador de una API web. Un controlador es una parte de una aplicación web que maneja las solicitudes HTTP entrantes y devuelve respuestas adecuadas. En este caso, el **`ProductoController`** maneja solicitudes relacionadas con productos, como obtener una lista de productos, obtener un producto por su ID, agregar, actualizar y eliminar productos. El controlador utiliza la clase **`EntityStore`** para realizar estas operaciones en la memoria o en la base de datos.

La relación entre estos archivos es la siguiente:

- El archivo **`ProductoController.cs`** utiliza la clase **`EntityStore`** para interactuar con las entidades **`Producto`**. Cuando se reciben solicitudes HTTP en los métodos del controlador, se llaman a los métodos correspondientes de **`EntityStore`** para realizar operaciones en las entidades **`Producto`**.
- La clase **`Producto`** (**`Producto.cs`**) define la estructura de los objetos que se manejan en la aplicación, y estos objetos son los que se agregan, actualizan y eliminan a través del controlador y **`EntityStore`**.

En resumen, **`ProductoController`** actúa como un intermediario entre las solicitudes HTTP que provienen de un cliente (como una aplicación web o una aplicación móvil) y los datos de productos representados por la clase **`Producto`** y gestionados por la clase **`EntityStore`**. Esto permite crear una API web que puede realizar operaciones CRUD en productos y proporcionar respuestas a las solicitudes de los usuarios.

---

---

---

---

## Finalmente así quedó la estructura.

![Untitled](Proyecto%20ApiFramework%204%208%2006ccd0dd308f4515a027b23cb8249a12/Untitled%201.png)

![Untitled](Proyecto%20ApiFramework%204%208%2006ccd0dd308f4515a027b23cb8249a12/Untitled%202.png)