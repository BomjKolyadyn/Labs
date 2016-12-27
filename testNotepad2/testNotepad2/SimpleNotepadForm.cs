using System;
using System.IO; //Для использования потоков класса StringReader;
using System.Drawing.Printing; //Для работы с компонентами, обеспечивающими возможность печати документов;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testNotepad2
{
    public partial class SimpleNotepadForm : Form
    {
        /// <summary>
        /// Инициализая формы программы;
        /// </summary>
        public SimpleNotepadForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка меню File (menuFile);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFile_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Кнопка New из кнопки меню File.(menuFileNew);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileNew_Click(object sender, EventArgs e)
        {
            if (m_DocumentChanged) //Проверка изменений в документе;
                MenuFileSaveAs();
                richTextBox1.Clear();
        }

        /// <summary>
        /// Открытие существующего файла;
        /// Метод для компонента открытия файлов.
        /// </summary>
        private void MenuFileOpen()
        {
            if (openFileDialog1.ShowDialog() ==   //
               System.Windows.Forms.DialogResult.OK && //При нажатии "Открыть" файл, возвращает значение DialogResult.OK
               openFileDialog1.FileName.Length > 0) // И, проверяет, чтобы длина имени файла была больше 0.
            {
                try // Попытка открытия файла.
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, //Загрузка файла; Имя файла,
                       RichTextBoxStreamType.RichText); //Формат файла *rtf.
                }
                catch (System.ArgumentException ex) // Ловим исключение если пытаемся открыть файл формата не *rtf.
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, // Загрузка файла; Имя файла,
                       RichTextBoxStreamType.PlainText); //Формат файла *txt.
                }

                this.Text = "Файл [" + openFileDialog1.FileName + "]"; //Пишем в шапке "Файл + путь к нему".
            }
        }                   

        /// <summary>
        /// Кнопка Open из кнопки меню File.(menuFileOpen);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            MenuFileOpen();
        }

        /// <summary>
        /// Сохранение документа в новом файле; Метод для компонента сохранения файлов.
        /// У метода saveFileDialog имеется несколько перегруженных вариантов. Можно задать два параметра: путь к файлу(и имя файла соответсвенно); тип файла;
        /// </summary>
        private void MenuFileSaveAs()
        {
            if (saveFileDialog1.ShowDialog() == //Если мы нажали "сохранить", то происходит сравнение со значением DialogResult.OK;
               System.Windows.Forms.DialogResult.OK && // Значение DialogResult.OK возвращается;
            saveFileDialog1.FileName.Length > 0) // Проверка на длину названия файла при сохранении;
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName); // Метод для сохранения файлов;
                m_DocumentChanged = false; // Сброс проверки изменений в документе;
                this.Text = "Файл [" + saveFileDialog1.FileName + "]"; // Выводит название сохраненного файла в заголовке программы.

            }
        }

        /// <summary>
        /// Кнопка Save из кнопки меню File.(menuFileSave);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileSave_Click(object sender, EventArgs e)
        {
            MenuFileSaveAs(); //Метод сохранения файла;
        }

        /// <summary>
        /// Кнопка SaveAs из кнопки меню File.(menuFileSaveAs);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            MenuFileSaveAs(); //Метод сохранения файла;
        }

        /// <summary>
        /// Настройка параметров страницы; Метод для вывода на экран диалогового окна настройки параметров страницы документа;
        /// </summary>
        private void MenuFilePageSetup()
        {
            pageSetupDialog1.ShowDialog();
        }

        /// <summary>
        /// Кнопка PageSetup из кнопки меню File.(menuFilePageSetup);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFilePageSetup_Click(object sender, EventArgs e)
        {
            MenuFilePageSetup(); //Метод вызова настроек печати страницы;
        }

        /// <summary>
        /// StringReader для печати содержимого редактора текста
        /// </summary>
        private StringReader m_myReader; //Поле

        /// <summary>
        /// Номер текущей распечатываемой страницы документа
        /// </summary>
        private uint m_PrintPageNumber; //Поле

        /// <summary>
        /// Предварительный просмотр перед печатью документа
        /// </summary>
        private void MenuFilePrintPreview()
        {
            m_PrintPageNumber = 1; //Делаем поле равным 1 (т.к. просмотр начнется с первой страницы);

            string strText = this.richTextBox1.Text; //Записывает содержимое файла блокнота в strText;
            m_myReader = new StringReader(strText); //класс StringReader записыват из strText в поле m_myReader;

            Margins margins = new Margins(100, 50, 50, 50); //Задаются размеры поля печатаемой страницы;
            printDocument1.DefaultPageSettings.Margins = margins;
            printPreviewDialog1.ShowDialog(); //Отображает панель предварительного просмотра;

            m_myReader.Close();//Закрытие потока;
        }

        /// <summary>
        /// Кнопка Print Preview из кнопки меню File.(menuFilePagePreview); 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFilePrintPreview_Click(object sender, EventArgs e)
        {
            MenuFilePrintPreview();//Метод предварительного просмотра печати;
        }

        /// <summary>
        /// Печать документа
        /// </summary>
        private void MenuFilePrint()
        {
            m_PrintPageNumber = 1;//Печать документа начинается с первой страницы;

            string strText = this.richTextBox1.Text; //В переменную strText типа string записывается текст блокнота;
            m_myReader = new StringReader(strText); //StringReader записывает(strText) в поле m_myReader;

            Margins margins = new Margins(100, 50, 50, 50); // Задается размер окна печати файла;
            printDocument1.DefaultPageSettings.Margins = margins; //Размер окна становится равным margins;

            if (printDialog1.ShowDialog() == DialogResult.OK) // Если нажимается кнопка "Ок"(печать), то ;
            {
                this.printDocument1.Print(); //Документ отправляется на печать методом Print;
            }
            m_myReader.Close(); //Поток(поле) m_myReader закрывается (Close);
        }

        /// <summary>
        /// Кнопка Print из кнопки меню File.(menuFilePrint);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFilePrint_Click(object sender, EventArgs e)
        {
            MenuFilePrint();
        }

        private bool m_DocumentChanged = false; //Поле bool для проверки изменений в документе;

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            if (m_DocumentChanged)
                MenuFileSaveAs();
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            m_DocumentChanged = true; //true - если что-либо написано в документе;
        }

        private void SimpleNotepadForm_Load(object sender, EventArgs e)
        {

        }
    }
}
