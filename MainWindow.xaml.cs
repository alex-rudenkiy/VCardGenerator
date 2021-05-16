using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MessagingToolkit.QRCode.Codec;
using Thought.vCards;
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;
using Rectangle = System.Drawing.Rectangle;

namespace LabelGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string svg1 = "";
        private string svg2 = "";

        private String templateSvg1 = "";
        private String templateSvg2 = "";


        public MainWindow()
        {
            InitializeComponent();

            //var fonts = Fonts.GetFontFamilies(new Uri("pack://application:,,,/Fonts/#"));
            //Debug.WriteLine(fonts);
            /*
*/




            /*MemoryStream lMemoryStream = new MemoryStream();
            Package package = Package.Open(lMemoryStream, FileMode.CreateNew);
            XpsDocument doc = new XpsDocument(package);
            XpsDocumentWriter xwriter = XpsDocument.CreateXpsDocumentWriter(doc);
            xwriter.Write(pd);
            doc.Close();
            package.Close();

            //var pdfXpsDoc = PdfSharp.Xps.XpsModel.XpsDocument.Open(lMemoryStream);
            var pdfXpsDoc = PdfSharp.Xps.XpsModel.XpsDocument.Open(lMemoryStream);
            PdfSharp.Xps.XpsConverter.Convert(pdfXpsDoc, "result.pdf", 0);
*/
            templateSvg1 = File.ReadAllText(@"Images\page_01.svg");
            templateSvg2 = File.ReadAllText(@"Images\page_02.svg");
            
            updateVCard();
            resourceSvgCanvasBack.SvgSource = templateSvg2;


            /**/
        }

        class ProfileInfo
        {
            public string name { get; set; } = "";
            public string surname { get; set; } = "";
            public string patronymic { get; set; } = "";
            public string position { get; set; } = "";
            public string phone1 { get; set; } = "";
            public string phone2 { get; set; } = "";
            public string email { get; set; } = "";
            public string academicDegree { get; set; } = "";
         
        }

        private ProfileInfo profile = new ProfileInfo();


            public static Bitmap ChangeColor(Bitmap image, Color fromColor, Color toColor)
            {
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetRemapTable(new ColorMap[]
                {
                    new ColorMap()
                    {
                        OldColor = fromColor,
                        NewColor = toColor,
                    }
                }, ColorAdjustType.Bitmap);

                using (Graphics g = Graphics.FromImage(image))
                {
                    g.DrawImage(
                        image,
                        new Rectangle(Point.Empty, image.Size),
                        0, 0, image.Width, image.Height,
                        GraphicsUnit.Pixel,
                        attributes);
                }

                return image;
            }
        


        void updateVCard()
        {

            if (resourceSvgCanvasFront != null)
            {
                svg1 = templateSvg1;
                /*svg1 = svg1.Replace("Имя отчество", string.Format("{0} {1}", profile.name, profile.patronymic));
                svg1 = svg1.Replace("Фамилия", string.Format("{0}", profile.surname));
                svg1 = svg1.Replace("Должность", string.Format("{0}", profile.position));
                svg1 = svg1.Replace("+7(499)", string.Format("{0}", profile.phone1));
                svg1 = svg1.Replace("+7(500)", string.Format("{0}", profile.phone2));
                svg1 = svg1.Replace("Электронная почта", string.Format("{0}", profile.email));*/
                myCanvasLabel1.Content = string.Format("{0} {1}", profile.name, profile.patronymic);
                myCanvasLabel2.Content = string.Format("{0}", profile.surname.ToUpper());
                myCanvasLabel3.Content = string.Format("{0}", profile.position);
                myCanvasLabel4.Content = string.Format("{0}", profile.phone1); Canvas.SetTop(myCanvasLabel4,55);
                myCanvasLabel5.Content = string.Format("{0}", profile.phone2); Canvas.SetTop(myCanvasLabel5,63);
                myCanvasLabel6.Content = string.Format("{0}", profile.email); Canvas.SetTop(myCanvasLabel6,72);
                myCanvasLabel7.Content = string.Format("{0}", profile.academicDegree);

                resourceSvgCanvasFront.SvgSource = svg1;

                vCard vCard = new vCard();
                //vCard.FormattedName = string.Format("{0}; {1}", profile.name, profile.patronymic);
                vCard.FamilyName = profile.surname;
                vCard.GivenName = profile.name;
                vCard.AdditionalNames = profile.patronymic;
                vCard.Websites.Add(new vCardWebsite("https://www.fintech.ru"));

                //vCard.Organization = "119180; Москва; ; 11А";
                //vCard.Office = "119180; Москва; 1-й Хвостов пер.; 11А";----
                //vCard.DeliveryAddresses.Add("119180, Москва, 1-й Хвостов пер., 11А");

                vCardDeliveryAddress address = new vCardDeliveryAddress();
                address.City = "Москва";
                address.Country = "Россия";
                address.AddressType.Add(vCardDeliveryAddressTypes.Work);
                address.Street = "1-й Хвостов переулок 11А";
                address.PostalCode = "119180";
                vCard.DeliveryAddresses.Add(address);

                vCard.Organization = "АО \"ФИНТЕХ\"";
                //vCard.Role = String.Format("{0}{1}",myCanvasLabel3.Content, myCanvasLabel7.Content.ToString().Length>0?", "+myCanvasLabel7.Content:"");
                //vCard.DisplayName = String.Format("{0}{1}", myCanvasLabel3.Content, myCanvasLabel7.Content.ToString().Length > 0 ? ", " + myCanvasLabel7.Content : "");
                //vCard.FormattedName = String.Format("{0}{1}", myCanvasLabel3.Content, myCanvasLabel7.Content.ToString().Length > 0 ? ", " + myCanvasLabel7.Content : "");
                //vCard.Nicknames.Add(String.Format("{0}{1}", myCanvasLabel3.Content, myCanvasLabel7.Content.ToString().Length > 0 ? ", " + myCanvasLabel7.Content : ""));
                //vCard.Notes.Add(String.Format("{0}{1}", myCanvasLabel3.Content, myCanvasLabel7.Content.ToString().Length > 0 ? ", " + myCanvasLabel7.Content : ""));
                vCard.Title = String.Format("{0}{1}", myCanvasLabel3.Content, myCanvasLabel7.Content.ToString().Length > 0 ? ". " + myCanvasLabel7.Content : ".");
                //vCard.SocialProfiles.Add(new vCardSocialProfile(String.Format("{0}{1}", myCanvasLabel3.Content, myCanvasLabel7.Content.ToString().Length > 0 ? ", " + myCanvasLabel7.Content : ""));
                if(myCanvasLabel7.Content.ToString().Length > 0)
                {
                    Canvas.SetTop(myCanvasLabel4, Canvas.GetTop(myCanvasLabel4) + 5);
                    Canvas.SetTop(myCanvasLabel5, Canvas.GetTop(myCanvasLabel5) + 5);
                    Canvas.SetTop(myCanvasLabel6, Canvas.GetTop(myCanvasLabel6) + 5);

                }


                //vCard.GivenName = string.Format("{0};{1};", profile.name, profile.patronymic);
                //vCard.FamilyName = string.Format("{0}", profile.surname);

                vCard.Phones.Add(new vCardPhone(profile.phone1.Replace(" ","").Replace("доб.",";"), vCardPhoneTypes.Default));
                vCard.Phones.Add(new vCardPhone(profile.phone2.Replace(" ", "").Replace("доб.", ";"), vCardPhoneTypes.Work));


                vCard.EmailAddresses.Add(new vCardEmailAddress(profile.email));


                // Save vCard data to string
                vCardStandardWriter writer = new vCardStandardWriter();
                stringWriter = new StringWriter();
                writer.Write(vCard, stringWriter);

                updateQRCode(1);

            }

        }

        StringWriter stringWriter = new StringWriter();

        void updateQRCode(int quality)
        {
            QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
            qRCodeEncoder.QRCodeScale = quality;
            Bitmap image = qRCodeEncoder.Encode(stringWriter.ToString());
            image = ChangeColor(image, Color.Black, System.Drawing.Color.FromArgb(17, 76, 138));


            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();


                img1.Source = bitmapImage;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            profile.name = (sender as TextBox).Text;
            updateVCard();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            profile.surname = (sender as TextBox).Text;
            updateVCard();
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            profile.patronymic = (sender as TextBox).Text;
            updateVCard();
        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            profile.position = (sender as TextBox).Text;
            updateVCard();
        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {
            profile.phone1 = (sender as TextBox).Text;
            updateVCard();
        }

        private void TextBox_TextChanged_5(object sender, TextChangedEventArgs e)
        {
            profile.phone2 = (sender as TextBox).Text;
            updateVCard();
        }

        private void TextBox_TextChanged_6(object sender, TextChangedEventArgs e)
        {
            profile.email = (sender as TextBox).Text;
            updateVCard();
        }

        public T XamlClone<T>(T source)
        {
            string savedObject = System.Windows.Markup.XamlWriter.Save(source);

            // Load the XamlObject
            StringReader stringReader = new StringReader(savedObject);
            System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(stringReader);
            T target = (T)System.Windows.Markup.XamlReader.Load(xmlReader);

            return target;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*PrintFrameWindow printFrame = new PrintFrameWindow();
            Grid sc = XamlClone(griid);
            sc.Margin = new Thickness(0, 0, 0, 0);
            Canvas.SetLeft(sc, 0);
            printFrame.Container.Children.Add(sc);
            printFrame.Show();*/


            blur.Radius = 45;


            updateQRCode(65);


            try
            {
                PrintDialog pd = new PrintDialog();
                pd.PrintQueue = new PrintQueue(new PrintServer(), "Microsoft Print to PDF");
                pd.PrintTicket.PageOrientation = PageOrientation.Landscape;
                pd.PrintTicket.PageScalingFactor = Convert.ToInt32(100 * scaler.Value);

                Thickness t1 = myCanvasFront.Margin;
                double t2 = Canvas.GetLeft(myCanvasFront);
                int t3 = Canvas.GetZIndex(myCanvasFront);

                myCanvasFront.Margin = new Thickness(0, 0, 0, 0);
                Canvas.SetZIndex(myCanvasFront, 100);
                Canvas.SetLeft(myCanvasFront, 0);
                pd.PrintVisual(myCanvasFront, "Nomograph");
                myCanvasFront.Margin = t1;
                Canvas.SetLeft(myCanvasFront, t2);
                Canvas.SetZIndex(myCanvasFront, t3);



                t1 = myCanvasBack.Margin;
                t2 = Canvas.GetLeft(myCanvasBack);
                t3 = Canvas.GetZIndex(myCanvasBack);

                myCanvasBack.Margin = new Thickness(0, 0, 0, 0);
                Canvas.SetZIndex(myCanvasBack, 100);
                Canvas.SetLeft(myCanvasBack, 0);
                pd.PrintVisual(myCanvasBack, "Nomograph");
                myCanvasBack.Margin = t1;
                Canvas.SetLeft(myCanvasBack, t2);
                Canvas.SetZIndex(myCanvasBack, t3);

                blur.Radius = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Возможно PDF в который вы хотите сохранить, открыт в какой-то стороней программе, введите другое название файла.");
            }
           


            /*pd.PrintQueue = new PrintQueue(new PrintServer(), "Microsoft Print to PDF");
            pd.PrintTicket.PageOrientation = PageOrientation.Landscape;
            pd.PrintTicket.PageScalingFactor = Convert.ToInt32(100 * scaler.Value);
            pd.PrintVisual(myCanvasBack, "Nomograph");*/


        }

        private void TextBox_TextChanged_7(object sender, TextChangedEventArgs e)
        {
            profile.academicDegree = (sender as TextBox).Text;
            updateVCard();
        }
    }
}
