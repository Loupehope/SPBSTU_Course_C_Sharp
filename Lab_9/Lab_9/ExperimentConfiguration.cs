using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public class ExperimentConfiguration
    {
        /// <summary>
        /// Радиус окружности
        /// </summary>
        public int radius;

        /// <summary>
        /// Число потоков
        /// </summary>
        public int threadsCount;

        /// <summary>
        /// Время сна потока
        /// </summary>
        public int sleepTime;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="radius">Радикс окружности</param>
        /// <param name="threadsCount">Число потоков</param>
        /// <param name="sleepTime">Время сна потока</param>
        public ExperimentConfiguration(int radius, int threadsCount, int sleepTime)
        {
            this.radius = radius;
            this.threadsCount = threadsCount;
            this.sleepTime = sleepTime;
        }
    }
}
