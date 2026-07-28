using System.Collections;

namespace GmnClass002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            【小练习 1.2】：实现敌人波次数据容器（EnemyWaveContainer）
            【背景模拟】：
            在 Unity 塔防游戏开发中，刷怪点（Spawner）需要持有整波敌人的类型列表。
            你需要创建一个敌人波次容器，使其实现 IEnumerable 接口，以便后续能够被遍历。

            【具体要求】：

            创建一个名为 EnemyWaveContainer 的类，实现 System.Collections.IEnumerable 接口。

            构造函数接收一个 string[] 类型的数组（表示本波次所有敌人的 Prefab 名称）。

            使用 ?? 运算符、nameof() 关键字与 ArgumentNullException 进行构造函数入参的防御性检查。

            实现 GetEnumerator() 方法，返回你在上一课中掌握的 IEnumerator 游标对象（可直接实例化上一课编写的 DialogueEnumerator，或重新编写一个通用/专用的 EnemyWaveEnumerator）。

            【变量/方法命名规范】：

            类名：EnemyWaveContainer

            私有成员变量：以下划线开头（如 _enemyTypes）

            接口成员：严格遵循 IEnumerable 规范签名

            请在下方回复你编写的代码。检查得分 60 分以上方可进入下一个知识点。
            */
            string[] enemys = { "Gobulin", "Boss", "RedBull" };
            EnemyWaveContainer container = new EnemyWaveContainer(enemys);
            foreach(var e in container)
            {
                Console.WriteLine(e);
            }

        }
    }

    public class EnemyWaveEnumerator : IEnumerator
    {
        private string[] _enemysList;
        private int _currentIndex = -1;
        public EnemyWaveEnumerator(string[] enemyList)
        {
            _enemysList = enemyList ?? throw new ArgumentNullException(nameof(enemyList));
        }
        public object Current => _enemysList[_currentIndex];

        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < _enemysList.Length;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }

    public class EnemyWaveContainer : IEnumerable
    {
        private string[] _enemyType;
        public EnemyWaveContainer(string[] lines)
        {
            _enemyType = lines ?? throw new ArgumentNullException(nameof(lines));
        }
        public IEnumerator GetEnumerator()
        {
            return new EnemyWaveEnumerator(_enemyType);
        }
    }
}
