namespace AttributeClass002
{
    public class RequiredRoleAttribute : Attribute
    {
        public string Role { get; }
        public RequiredRoleAttribute(string role)
        {
            Role = role;
        }
    }

    [RequiredRole("Admin")]
    public class RechargeManager
    {

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ===================================================================
            背景模拟：
            你在为网络游戏开发一个简易的权限管理系统。某些高危敏感方法（如：充值、
            删除账号）必须打上权限标签，并且在调用前通过反射校验执行人员的身份。

            具体要求：
            1. 声明一个自定义特性类，类名必须严格符合命名规范。
               - 构造函数接收一个 string 类型的权限级别名称（Role）。
               - 包含一个只读属性存储该权限名称。
            2. 声明一个充值管理类（RechargeManager）。
            3. 将声明的权限特性挂载到 RechargeManager 类上，传入权限级别为 "Admin"。
            4. 在 Main 方法中，利用本节所学的 Attribute.GetCustomAttribute 静态方法，
               动态获取 RechargeManager 类上挂载的权限特性。
            5. 编写防御性代码，若获取到的特性不为 null，则在控制台打印出：
               "验证通过，当前操作需要权限：[权限级别名称]"
               （注：[权限级别名称] 需动态替换为从特性中读取出来的属性值）。

            变量/方法命名规范：
            - 特性类名：RequiredRoleAttribute
            - 特性中的只读属性：Role
            - 目标类名：RechargeManager
            ===================================================================
            */
            Type type = typeof(RechargeManager);
            Attribute? rawAttribute = Attribute.GetCustomAttribute(type, typeof(RequiredRoleAttribute));
            if(rawAttribute != null)
            {
                //强制转换特性
                RequiredRoleAttribute attribute = (RequiredRoleAttribute)rawAttribute;
                Console.WriteLine($"验证通过，当前操作需要权限：[{attribute.Role}]");
            }
        }
    }
}
