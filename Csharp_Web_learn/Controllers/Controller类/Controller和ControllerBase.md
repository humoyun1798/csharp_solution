
**ControllerBase**  webapi要继承的
**Controller** 在ControllerBase的基础上加了对**视图**的支持


在 .NET 中，控制器（Controller）是构建 Web API 的核心组件，负责处理客户端请求并返回响应。以下是关于 .NET Controller API 需要学习的核心内容：


### **1. 控制器基础**
- **控制器定义**：继承自 `ControllerBase`（用于 API）或 `Controller`（用于 MVC + API）的类。
- **路由配置**：通过属性路由（如 `[Route]`、`[HttpGet]`）或约定路由定义 API 路径。
- **依赖注入**：通过构造函数注入服务（如数据库上下文、业务逻辑）。

**示例**：
```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
}
```


### **2. HTTP 方法特性**
- **常用特性**：`[HttpGet]`、`[HttpPost]`、`[HttpPut]`、`[HttpDelete]`、`[HttpPatch]`。
- **路由参数**：通过 `{id}` 捕获 URL 中的参数。

**示例**：
```csharp
[HttpGet("{id}")]
public IActionResult GetProduct(int id)
{
    var product = _productService.GetById(id);
    if (product == null)
        return NotFound();
    return Ok(product);
}

[HttpPost]
public IActionResult CreateProduct([FromBody] Product product)
{
    _productService.Create(product);
    return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
}
```


### **3. 请求参数绑定**
- **参数来源**：
  - `[FromBody]`：从请求体中读取（JSON/XML）。
  - `[FromQuery]`：从 URL 查询字符串读取（如 `?page=1`）。
  - `[FromRoute]`：从路由参数读取（如 `{id}`）。
  - `[FromHeader]`：从请求头读取。
  - `[FromForm]`：从表单数据读取（用于文件上传等）。

**示例**：
```csharp
[HttpGet]
public IActionResult SearchProducts([FromQuery] string category, [FromQuery] int page = 1)
{
    var products = _productService.Search(category, page);
    return Ok(products);
}
```


### **4. 响应结果**
- **常见返回类型**：
  - `Ok(object)`：200 OK，返回数据。
  - `CreatedAtAction(string actionName, object routeValues, object value)`：201 Created，用于创建资源。
  - `NoContent()`：204 No Content，用于无返回值的操作。
  - `NotFound()`：404 Not Found，资源不存在。
  - `BadRequest()`：400 Bad Request，请求无效。
  - `Unauthorized()`：401 Unauthorized，未授权。
  - `Forbid()`：403 Forbidden，权限不足。

**示例**：
```csharp
[HttpDelete("{id}")]
public IActionResult DeleteProduct(int id)
{
    var success = _productService.Delete(id);
    if (!success)
        return NotFound();
    return NoContent();
}
```


### **5. 过滤器（Filters）**
- **类型**：
  - **授权过滤器**（`IAuthorizationFilter`）：验证用户权限。
  - **资源过滤器**（`IResourceFilter`）：在模型绑定前后执行。
  - **动作过滤器**（`IActionFilter`）：在动作执行前后执行。
  - **异常过滤器**（`IExceptionFilter`）：处理未捕获的异常。
  - **结果过滤器**（`IResultFilter`）：在结果执行前后执行。

**示例**：
```csharp
public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        context.Result = new ObjectResult(new { error = "Internal server error" })
        {
            StatusCode = 500
        };
    }
}
```


### **6. 模型验证**
- **数据注解**：使用 `[Required]`、`[MaxLength]`、`[Range]` 等特性验证输入模型。
- **自动验证**：若模型无效，自动返回 400 Bad Request。

**示例**：
```csharp
public class Product
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
}
```


### **7. 版本控制**
- **URL 版本控制**：如 `[Route("api/v{version:apiVersion}/products")]`。
- **查询参数版本控制**：如 `?api-version=2.0`。
- **请求头版本控制**：如 `Accept-Version: 2.0`。

**示例**：
```csharp
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductsV1Controller : ControllerBase { /* ... */ }

[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductsV2Controller : ControllerBase { /* ... */ }
```


### **8. 高级特性**
- **Swagger/OpenAPI**：自动生成 API 文档。
- **CORS（跨域资源共享）**：配置跨域请求。
- **文件上传**：使用 `IFormFile` 处理文件。
- **异步操作**：返回 `Task<IActionResult>` 提升性能。
- **HATEOAS**：返回包含链接的资源（如 RESTful API）。


### **学习资源**
- [官方文档：ASP.NET Core Web API](https://docs.microsoft.com/aspnet/core/web-api)
- [ASP.NET Core 实战](https://www.amazon.com/dp/1617298060)（书籍）
- [YouTube 教程](https://www.youtube.com/watch?v=D8UvwHS3c1c)

掌握以上内容后，你将能够构建完整、健壮的 .NET Web API 控制器。