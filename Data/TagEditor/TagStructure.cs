using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WorkProject.Main.TagEditor
{
    public static class TagStructure
    {
        public static class ReqCond
        {
            public static XElement Applied => new XElement("reqCondGroup",
                new XElement("reqCondNoRef",
                    new XElement("reqCond", "Требуемое условие.")
                )
            );

            public static XElement NotApplied => new XElement("reqCondGroup",
                new XElement("noConds")
            );
        }

        public static class ReqPersons
        {
            public static XElement Applied => new XElement("reqPersons",
                new XElement("person", new XAttribute("man", "A"),
                    new XElement("personCategory", new XAttribute("personCategoryCode", "Слесарь по ремонту автомобилей")),
                    new XElement("personSkill", new XAttribute("skillLevelCode", "sk53")),
                    new XElement("trade", "18511"),
                    new XElement("estimatedTime", new XAttribute("unitOfMeasure", "h"), "0.344")
                )
            );

            public static XElement NotApplied => new XElement("reqPersons",
                new XElement("noPersons")
            );
        }

        public static class SupportEquip
        {
            public static XElement Applied => new XElement("reqSupportEquips",
                new XElement("supportEquipDescrGroup",
                    new XElement("supportEquipDescr",
                        new XElement("name", "Наименование инструмента"),
                        new XElement("identNumber",
                            new XElement("manufacturerCode"),
                            new XElement("partAndSerialNumber",
                                new XElement("partNumber", "обозначение инструмента")
                            )
                        ),
                        new XElement("reqQuantity", new XAttribute("unitOfMeasure", "EA"), "1")
                    )
                )
            );

            public static XElement NotApplied => new XElement("reqSupportEquips",
                new XElement("noSupportEquips")
            );
        }

        public static class Supplies
        {
            public static XElement Applied => new XElement("reqSupplies",
                new XElement("supplyDescrGroup",
                    new XElement("supplyDescr",
                        new XElement("name", "Смазка универсальная..."),
                        new XElement("identNumber",
                            new XElement("manufacturerCode"),
                            new XElement("partAndSerialNumber",
                                new XElement("partNumber", "Material_Smazka_universalnaya")
                            )
                        ),
                        new XElement("reqQuantity", new XAttribute("unitOfMeasure", "EA"), "1")
                    )
                )
            );

            public static XElement NotApplied => new XElement("reqSupplies",
                new XElement("noSupplies")
            );
        }

        public static class Spares
        {
            public static XElement Applied => new XElement("reqSpares",
                new XElement("spareDescrGroup",
                    new XElement("spareDescr",
                        new XElement("name", "Подшипник качения"),
                        new XElement("identNumber",
                            new XElement("manufacturerCode"),
                            new XElement("partAndSerialNumber",
                                new XElement("partNumber", "Part_Bearing")
                            )
                        ),
                        new XElement("reqQuantity", new XAttribute("unitOfMeasure", "EA"), "1")
                    )
                )
            );

            public static XElement NotApplied => new XElement("reqSpares",
                new XElement("noSpares")
            );
        }

        public static class Safety
        {
            public static XElement Applied => new XElement("reqSafety",
                new XElement("safetyRqmts",
                    new XElement("note", new XAttribute("id", "warningN655367"),
                        new XElement("notePara", "Применяемые в данной технологической карте...")
                    )
                )
            );

            public static XElement NotApplied => new XElement("reqSafety",
                new XElement("noSafety")
            );
        }

        public static class ProceduralStep
        {
            public static XElement Applied => new XElement("proceduralStep",
                new XElement("title", "Заголовок"),
                new XElement("para", "Текст процедурного шага"),
                new XElement("para", "Текст процедурного шага")
            );

            public static XElement NotApplied => new XElement("proceduralStep",
                new XElement("noSteps")
            );
        }

        public static class ClosedReqCond
        {
            public static XElement Applied => new XElement("reqCondGroup",
                new XElement("reqCondNoRef",
                    new XElement("reqCond", "Работы сопутствующего ремонта.")
                )
            );

            public static XElement NotApplied => new XElement("reqCondGroup",
                new XElement("noConds")
            );
        }
    }















}
