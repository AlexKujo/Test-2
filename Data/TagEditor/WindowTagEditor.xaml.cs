using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using static System.Net.WebRequestMethods;

namespace WorkProject.Main.TagEditor
{
    /// <summary>
    /// Логика взаимодействия для WindowTagEditor.xaml
    /// </summary>
    public partial class WindowTagEditor : Window
    {
        private ObservableCollection<Block> _blocks;
        private BlockFactory _blockFactory;
        private List<Block> _visibleBlocks;

        private StringBuilder _result;
        private string _XsdSchema = "http://www.s1000d.org/S1000D_4-1/xml_schema_flat/proced.xsd";

        public WindowTagEditor()
        {
            InitializeComponent();

            _blockFactory = new BlockFactory();
            List<Block> blocksList = _blockFactory.CreateBlocksList();

            _blocks = new ObservableCollection<Block>(blocksList);

            _visibleBlocks = new List<Block>();

            TextBlocks.ItemsSource = _blocks;

            _result = new StringBuilder();
        }

        private void Applied_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            Block selectedBlock = comboBox.DataContext as Block;

            string TagApplied = (comboBox.Items[0] as ComboBoxItem).Content.ToString();
            string TagNotApplied = (comboBox.Items[1] as ComboBoxItem).Content.ToString();

            if (selectedBlock.NotAppliedTagStructure == null)
            {
                comboBox.IsEnabled = false;
            }

            if (TagApplied == comboBox.SelectedValue.ToString())
            {
                selectedBlock.IsApplied = true;
                //selectedBlock.CurrentTagStructure = selectedBlock.AppliedTagStructure;
            }
            else if (TagNotApplied == comboBox.SelectedValue.ToString())
            {
                selectedBlock.IsApplied = false;
                //selectedBlock.CurrentTagStructure = selectedBlock.NotAppliedTagStructure;
            }
        }

        private List<Block> GetRqmtsVisibleBlocks()
        {
            // Фильтруем блоки по условию видимости и id
            List<Block> checkedBlocks = _blocks
                .Where(block =>
                    (block.IdName == Id.reqCond ||
                     block.IdName == Id.reqPersons ||
                     block.IdName == Id.reqSupplies ||
                     block.IdName == Id.reqSupportEquips) &&
                    block.IsVisible)
                .ToList(); // Преобразуем результат в список

            return checkedBlocks;
        }

        private Block GetVisibleBlock(Id IdName)
        {
            return _blocks
                .FirstOrDefault(block => block.IdName == IdName && block.IsVisible);
        }

        private List<Block> GetVisibleBlocks(params Id[] idNames)
        {
            // Ищем видимые блоки с указанными идентификаторами
            List<Block> blocks = _blocks
                                       .Where(block =>
                                           idNames.Contains(block.IdName) &&
                                           block.IsVisible)
                                       .ToList();

            return blocks;
        }

        private void CopyAll_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(GetContentBlock().ToString());
            MessageBox.Show("Теги скопированы в буфер обмена");
        }

        private XDocument GetContentBlock()
        {
            List<Block> rqmtsBlocks = GetVisibleBlocks(Id.reqCond, Id.reqPersons, Id.reqSupportEquips, Id.reqSupplies, Id.reqSpares, Id.reqSafety);
            Block mainProcedureBlock = GetVisibleBlocks(Id.proceduralStep).FirstOrDefault();
            Block closedRqmtsBlock = GetVisibleBlocks(Id.closeReqCond).FirstOrDefault();

            // Создаем корневой элемент
            XElement content = new XElement("content");
            XElement procedure = new XElement("procedure");
            content.Add(procedure);

            // Формируем preliminaryRqmts
            XElement preliminaryRqmts = new XElement("preliminaryRqmts");

            foreach (Block block in rqmtsBlocks)
            {
                if (block.CurrentTagStructure != null)
                {
                    preliminaryRqmts.Add(block.CurrentTagStructure);  // Добавляем содержимое XDocument
                }
            }
            procedure.Add(preliminaryRqmts);

            // Добавляем mainProcedure, если есть содержимое
            if (mainProcedureBlock?.CurrentTagStructure != null)
            {
                XElement mainProcedure = new XElement("mainProcedure", mainProcedureBlock.CurrentTagStructure);
                procedure.Add(mainProcedure);
            }

            // Добавляем closeRqmts, если есть содержимое
            if (closedRqmtsBlock?.CurrentTagStructure != null)
            {
                XElement closeRqmts = new XElement("closeRqmts", closedRqmtsBlock.CurrentTagStructure);
                procedure.Add(closeRqmts);
            }

            XDocument finalDocument = new XDocument(content);
            return finalDocument;
        }


        private void Validate_Click(object sender, RoutedEventArgs e)
        {
            // Флаг для отслеживания ошибок валидации
            bool hasErrors = false;
            string errorMessage = string.Empty;

            // Создаем XmlSchemaSet и загружаем схему
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add("", $"{_XsdSchema}");
            schemaSet.Compile();

            // Создаем XmlReaderSettings и указываем схему
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas = schemaSet;
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += (validationSender, validationEventArgs) =>
            {
                errorMessage = $"Ошибка валидации: {validationEventArgs.Message}";
                hasErrors = true;
            };

            // Получаем XDocument из метода
            XDocument document = GetContentBlock();

            // Создаем XmlReader для проверки элемента по схеме
            using (XmlReader reader = XmlReader.Create(document.CreateReader(), settings))
            {
                try
                {
                    while (reader.Read()) { }
                }
                catch (XmlException ex)
                {
                    errorMessage = $"Ошибка: {ex.Message}";
                    hasErrors = true;
                }
            }

            if (hasErrors)
            {
                MessageBox.Show(errorMessage, "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Валидация прошла успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void GenerateFullXmlDocument()
        {
            // Создаем диалог для сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml"; // Фильтр для выбора только файлов .xml
            saveFileDialog.Title = "Сохранить XML документ";

            // Если пользователь выбрал файл и нажал "Сохранить"
            if (saveFileDialog.ShowDialog() == true)
            {
                string outputPath = saveFileDialog.FileName;

                // Создаем заголовок XML-документа
                XDocument fullDocument = new XDocument(new XDeclaration("1.0", "UTF-8", "no"));

                // Определяем пространства имен
                XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
                XNamespace xlink = "http://www.w3.org/1999/xlink";
                XNamespace rdf = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";
                XNamespace dc = "http://www.purl.org/dc/elements/1.1/";

                // Создаем корневой элемент dmodule с необходимыми атрибутами
                XElement root = new XElement("dmodule",
                    new XAttribute(XNamespace.Xmlns + "xsi", xsi),
                    new XAttribute(XNamespace.Xmlns + "xlink", xlink),
                    new XAttribute(XNamespace.Xmlns + "rdf", rdf),
                    new XAttribute(XNamespace.Xmlns + "dc", dc),
                    new XAttribute(xsi + "noNamespaceSchemaLocation", "http://www.s1000d.org/S1000D_4-1/xml_schema_flat/proced.xsd"));

                // Добавляем идентификационный блок и статус
                XElement identAndStatusSection = new XElement("identAndStatusSection",
                    new XElement("dmAddress",
                        new XElement("dmIdent",
                            new XElement("dmCode",
                                new XAttribute("modelIdentCode", "KAMAZ53949"),
                                new XAttribute("systemDiffCode", "A"),
                                new XAttribute("systemCode", "00"),
                                new XAttribute("subSystemCode", "0"),
                                new XAttribute("subSubSystemCode", "0"),
                                new XAttribute("assyCode", "00"),
                                new XAttribute("disassyCode", "00"),
                                new XAttribute("disassyCodeVariant", "A"),
                                new XAttribute("infoCode", "000"),
                                new XAttribute("infoCodeVariant", "A"),
                                new XAttribute("itemLocationCode", "D")),
                            new XElement("language",
                                new XAttribute("countryIsoCode", "RU"),
                                new XAttribute("languageIsoCode", "ru")),
                            new XElement("issueInfo",
                                new XAttribute("issueNumber", "000"),
                                new XAttribute("inWork", "01"))
                        ),
                        new XElement("dmAddressItems",
                            new XElement("issueDate",
                                new XAttribute("year", "2023"),
                                new XAttribute("month", "01"),
                                new XAttribute("day", "29")),
                            new XElement("dmTitle",
                                new XElement("techName", "Технологическое имя модуля данных"))
                        )
                    ),
                    new XElement("dmStatus",
                        new XAttribute("issueType", "new"),
                        new XElement("security", new XAttribute("securityClassification", "01")),
                        new XElement("responsiblePartnerCompany"),
                        new XElement("originator"),
                        new XElement("applic",
                            new XElement("displayText",
                                new XElement("simplePara"))),
                        new XElement("brexDmRef",
                            new XElement("dmRef",
                                new XElement("dmRefIdent",
                                    new XElement("dmCode",
                                        new XAttribute("modelIdentCode", "S1000D"),
                                        new XAttribute("systemDiffCode", "E"),
                                        new XAttribute("systemCode", "04"),
                                        new XAttribute("subSystemCode", "1"),
                                        new XAttribute("subSubSystemCode", "0"),
                                        new XAttribute("assyCode", "0301"),
                                        new XAttribute("disassyCode", "00"),
                                        new XAttribute("disassyCodeVariant", "A"),
                                        new XAttribute("infoCode", "022"),
                                        new XAttribute("infoCodeVariant", "A"),
                                        new XAttribute("itemLocationCode", "D"))))),
                        new XElement("qualityAssurance", new XElement("unverified"))
                    )
                );

                // Добавляем идентификационный блок к корневому элементу
                root.Add(identAndStatusSection);

                // Получаем контентный блок из метода GetContentBlock
                XDocument contentDocument = GetContentBlock();

                // Вставляем контентный блок внутрь корневого элемента
                XElement contentBlock = contentDocument.Root;
                root.Add(contentBlock);

                // Добавляем корневой элемент в полный документ
                fullDocument.Add(root);

                // Сохраняем документ в указанный путь
                fullDocument.Save(outputPath);

                MessageBox.Show("Документ успешно создан и сохранен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ExportFile_Click(object sender, RoutedEventArgs e)
        {
            GenerateFullXmlDocument();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            var selectedBlock = TextBlocks.SelectedItem as Block;

            if (selectedBlock != null)
            {
                Clipboard.SetText(selectedBlock.CurrentTagStructure.ToString());
                MessageBox.Show($"\"{selectedBlock.Title}\" скопировано в буфер обмена");
            }
        }
    }
}
