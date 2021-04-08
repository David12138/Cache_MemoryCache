using System;

namespace CacheDemo
{
    /// <summary>
    /// 控制台方法入口
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 缓存尽量在数据量小、重复查询量大的情况下使用。因为缓存也是要耗内存的，服务器内存是有限的！
             * 
             */
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"------第{i}次请求------");
                int result = 0;

                string key = "DataSource_GetDataByDB_666";

                DateTime dt = DateTime.Now.AddDays(1);
                result = CacheHelper.GetOrAddCacheItem(key, () => DataSource.GetDataByDB(666), dt, null);
                Console.WriteLine($"第{i}次请求获得的数据为：{result}");
            }

            //让窗体保存接受外部参数的状态来达到不退出的效果
            Console.ReadKey();
        }
    }
}