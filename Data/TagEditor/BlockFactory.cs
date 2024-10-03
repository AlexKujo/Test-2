using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;

namespace WorkProject.Main.TagEditor
{
    public class BlockFactory
    {
        public List<Block> CreateBlocksList()
        {
            List<Block> blocks = new List<Block>();

            blocks.Add(CreateRequiredCondition());        // Требуемые условия()
            blocks.Add(CreateRequiredPersons());          // Требуемый персонал
            blocks.Add(CreateSupportEquipment());         // Вспомогательное оборудование
            blocks.Add(CreateRequiredSupplies());         // Расходные материалы
            blocks.Add(CreateRequiredSpares());           // Запасные части
            blocks.Add(CreateRequiredSafety());           // Меры безопасности
            blocks.Add(CreateMainProcedureStep());        // Шаги
            blocks.Add(CreateClosedRequiredConditions()); // Работы сопутствующего ремонта

            return blocks;
        }

        private static Block CreateBlock(string name, Id idName, string contentApply)
        {
            return new Block(
                title: name,
                idName: idName,
                contentApply: contentApply
            );
        }

        // Требуемые условия
        public static Block CreateRequiredCondition(string contentApply = "Требуемое условие.")
        {
            var block = CreateBlock("Требуемые условия", Id.reqCond, contentApply);

            block.AppliedTagStructure = TagStructure.ReqCond.Applied;
            block.NotAppliedTagStructure = TagStructure.ReqCond.NotApplied;

            return block;
        }

        // Требуемый персонал
        public static Block CreateRequiredPersons(string contentApply = "Слесарь по ремонту автомобилей Разряд 3 sk53 18511 0.344 чел*ч Работник А")
        {
            var block = CreateBlock("Требуемый персонал", Id.reqPersons, contentApply);

            block.AppliedTagStructure = TagStructure.ReqPersons.Applied;

            block.IsSwitchable = true;

            return block;
        }

        // Вспомогательное оборудование
        public static Block CreateSupportEquipment(string contentApply = "Наименование инструмента обозначение инструмента")
        {
            var block = CreateBlock("Вспомогательное оборудование", Id.reqSupportEquips, contentApply);

            block.AppliedTagStructure = TagStructure.SupportEquip.Applied;
            block.NotAppliedTagStructure = TagStructure.SupportEquip.NotApplied;

            return block;
        }

        // Расходные материалы
        public static Block CreateRequiredSupplies(string contentApply = "Смазка универсальная, очищающая, противокоррозионная P/N: Material_Smazka_universalnaya 1шт.")
        {
            var block = CreateBlock("Расходные материалы", Id.reqSupplies, contentApply);

            block.AppliedTagStructure = TagStructure.Supplies.Applied;
            block.NotAppliedTagStructure = TagStructure.Supplies.NotApplied;

            return block;
        }

        // Запасные части
        public static Block CreateRequiredSpares(string contentApply = "Наименование запчасти P/N: обозначение запчасти 1шт. ДЗ")
        {
            var block = CreateBlock("Запасные части", Id.reqSpares, contentApply);

            block.AppliedTagStructure = TagStructure.Spares.Applied;
            block.NotAppliedTagStructure = TagStructure.Spares.NotApplied;

            return block;
        }

        // Меры безопасности
        public static Block CreateRequiredSafety(string contentApply = "Применяемые в данной технологической карте расходные материалы, приборы, инструменты и приспособления имеют рекомендательный характер.")
        {
            var block = CreateBlock("Меры безопасности", Id.reqSafety, contentApply);

            block.AppliedTagStructure = TagStructure.Safety.Applied;
            block.NotAppliedTagStructure = TagStructure.Safety.NotApplied;

            return block;
        }

        // Процедурный шаг
        public static Block CreateMainProcedureStep(string contentApply = "Текст процедурного шага")
        {
            var block = CreateBlock("Процедурный шаг", Id.proceduralStep, contentApply);

            block.AppliedTagStructure = TagStructure.ProceduralStep.Applied;

            return block;
        }

        // Работы сопутствующего ремонта
        public static Block CreateClosedRequiredConditions(string contentApply = "Работы сопутствующего ремонта.")
        {
            var block = CreateBlock("Работы сопутствующего ремонта", Id.closeReqCond, contentApply);

            block.AppliedTagStructure = TagStructure.ClosedReqCond.Applied;
            block.NotAppliedTagStructure = TagStructure.ClosedReqCond.NotApplied;

            return block;
        }

    }

    public class Block
    {
        public string Title { get; set; }

        public Id IdName { get; set; }

        public string ContentApply { get; set; }

        public string ContentNotApply { get; set; }

        public bool IsApplied { get; set; }

        public bool IsVisible { get; set; }

        public bool IsSwitchable { get; set; }

        public XElement AppliedTagStructure { get; set; }

        public XElement NotAppliedTagStructure { get; set; }

        public XElement CurrentTagStructure => IsApplied ? AppliedTagStructure : NotAppliedTagStructure;

        public Block(string title, Id idName, string contentApply, string contentNotApply = "Не применяется",
                 bool isApplied = true, bool isVisible = true, bool isSwitchable = false)
        {
            Title = title;
            IdName = idName;
            ContentApply = contentApply;
            ContentNotApply = contentNotApply;
            IsApplied = isApplied;
            IsVisible = isVisible;
            IsSwitchable = isSwitchable;
        }
    }

    public enum Id
    {
        reqCond,
        reqPersons,
        reqSupportEquips,
        reqSupplies,
        reqSpares,
        reqSafety,
        proceduralStep,
        closeReqCond
    }
}
