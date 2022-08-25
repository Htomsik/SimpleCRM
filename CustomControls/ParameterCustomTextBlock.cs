using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControls
{
   
    public class ParameterCustomTextBlock : Control
    {
        static ParameterCustomTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ParameterCustomTextBlock), new FrameworkPropertyMetadata(typeof(ParameterCustomTextBlock)));
        }
        
        #region HeaderText : Заголовок

        /// <summary>
        /// Заголовок текста
        /// </summary>
        public string HeaderText
        {
            get => (string)GetValue(HeaderTextProperty);
            set => SetValue(HeaderTextProperty, value);
        }
        
        public static DependencyProperty HeaderTextProperty = 
            DependencyProperty.Register(
                "HeaderText",
                typeof(string),
                typeof(ParameterCustomTextBlock));

        #endregion
        
        #region ParamText : Аргумент 
        
        /// <summary>
        /// Заголовок текста
        /// </summary>
        public string ParamText
        {
            get => (string)GetValue(ParamTextProperty);
            set => SetValue(ParamTextProperty, value);
        }
        
        public static DependencyProperty ParamTextProperty = 
            DependencyProperty.Register(
                "ParamText",
                typeof(string),
                typeof(ParameterCustomTextBlock));

        #endregion

        #region HeaderFontSize : Размер шрифта заголовка

        /// <summary>
        /// FontSize для HeaderText
        /// </summary>
        [TypeConverter(typeof(FontSizeConverter))]
        [Localizability(LocalizationCategory.None)]
        public double HeaderFontSize
        {
            get { return (double) GetValue(HeaderFontSizeProperty); }
            set { SetValue(HeaderFontSizeProperty, value); }
        }
        
        public static DependencyProperty HeaderFontSizeProperty = 
            DependencyProperty.Register(
                "HeaderFontSize",
                typeof(double),
                typeof(ParameterCustomTextBlock));
        

        #endregion
        
        #region ParamFontSize : Размер шрифта параметра

        /// <summary>
        /// FontSize для ParamText
        /// </summary>
        [TypeConverter(typeof(FontSizeConverter))]
        [Localizability(LocalizationCategory.None)]
        public double ParamFontSize
        {
            get { return (double) GetValue(ParamFontSizeProperty); }
            set { SetValue(ParamFontSizeProperty, value); }
        }
        
        public static DependencyProperty ParamFontSizeProperty = 
            DependencyProperty.Register(
                "ParamFontSize",
                typeof(double),
                typeof(ParameterCustomTextBlock));
        

        #endregion

        #region HeaderForeground : Цвет заголовка

        /// <summary>
        /// Цвет HeaderText
        /// </summary>
        public Brush HeaderForeground
        {
            get => (Brush)GetValue(HeaderForegroundProperty);
            set => SetValue(HeaderForegroundProperty, value);
        }
        
        public static DependencyProperty HeaderForegroundProperty = 
            DependencyProperty.Register(
                "HeaderForeground",
                typeof(Brush),
                typeof(ParameterCustomTextBlock));

        #endregion
        
        #region ParamForeground : Цвет параметра

        /// <summary>
        /// Цвет HeaderText
        /// </summary>
        public Brush ParamForeground
        {
            get => (Brush)GetValue(ParamForegroundProperty);
            set => SetValue(ParamForegroundProperty, value);
        }
        
        public static DependencyProperty ParamForegroundProperty = 
            DependencyProperty.Register(
                "ParamForeground",
                typeof(Brush),
                typeof(ParameterCustomTextBlock));
        
        



        #endregion

       
    }
}
