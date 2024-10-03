﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkProject.TextTemplates
{
    internal class Template
    {
        public float MinMomentKgSFM { get; set; }

        public float MaxMomentKgSFM { get; set; }

        public double MinMomentHM => ConvertMoment(MinMomentKgSFM);

        public double MaxMomentHM => ConvertMoment(MaxMomentKgSFM);

        public string ImpactPoints { get; set; }

        public string Text { get; private set; }

        public List<string> Tools { get; set; } = new List<string>();

        private double ConvertMoment(float valueInKgF) => Math.Round(valueInKgF * 9.80664999999931, 1);

        private string CapitalizeFirstLetter(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            return char.ToLower(text[0]) + text.Substring(1);
        }

        public string GenerateInstallationText()
        {
            var toolsFormatted = Tools.Select(tool => CapitalizeFirstLetter(tool));

            return $"Завернуть ##### (см. рисунок #, позиция 1) ##### (см. рисунок #, позиция 2). " +
                   $"Момент затяжки от {MinMomentHM} до {MaxMomentHM} Н*м ({MinMomentKgSFM}...{MaxMomentKgSFM} кгс*м). " +
                   $"Количество точек воздействия: {ImpactPoints}. Применяемый инструмент: {string.Join(", ", toolsFormatted)}.";
        }

        public string GenerateRemoveText()
        {
            var toolsFormatted = Tools.Select(tool => CapitalizeFirstLetter(tool));

            return $"Очистить гайки (см. рисунок 1, позиция 1) крепления ##### (см. рисунок 1, позиция 2). " +
                $"Применяемый инструмент: щетка металлическая. Расходный материал: смазка универсальная, очищающая, противокоррозионная." +
                $"\r\n\r\nОтвернуть гайки (см. рисунок 1, позиция 1) крепления ##### (см. рисунок 1, позиция 2)." +
                $" Количество точек воздействия: {ImpactPoints}. Применяемый инструмент: {string.Join(", ", toolsFormatted)}.";
        }
    }
}
