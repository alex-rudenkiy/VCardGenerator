   M S B A M L   `   `   `  ���� I  ELabelGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:LabelGeneratorLabelGenerator      LabelGenerator.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:LabelGenerator     b ^SharpVectors.Converters.Wpf, Version=1.7.1.0, Culture=neutral, PublicKeyToken=b532964b8548be771svgc&http://sharpvectors.codeplex.com/svgc/    � Title$4  .Генератор визиток ФинТех��$	��533��$	��618�� � 
ResizeMode$ NoResize=�.���  J� Effect -  'System.Windows.Media.Effects.BlurEffect  -   blur��   Radius$ 0Q�   RenderingBias$ Quality=�.+��� $$��Основные данные:��$
��Left=�$��	23,20,0,0q�$	��Top=�$��16(�$��Normal"��� -    ��Name$ nameChanged��$
��Left=�$��
109,75,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��120���� $��Имя��$
��Left=�$��	30,71,0,0q�$	��Top=��� -   $
��Left=�$��109,101,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��120���� $��Фамилия��$
��Left=�$��	30,97,0,0q�$	��Top=��� -   $
��Left=�$��109,127,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��120���� $��Отчество��$
��Left=�$��
30,123,0,0q�$	��Top=��� -   $
��Left=�$��
60,180,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��169��$��40���� $��Должность��$
��Left=�$��
30,149,0,0q�$	��Top=��� $(��"Мобильный номер №1��$
��Left=�$��
30,299,0,0q�$	��Top=��� -   $
��Left=�$��
60,325,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��169���� $(��"Мобильный номер №2��$
��Left=�$��
30,342,0,0q�$	��Top=��� -   $
��Left=�$��
60,369,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��169���� $'��!Электронный адрес��$
��Left=�$��
30,386,0,0q�$	��Top=��� -   $
��Left=�$��
60,413,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��169��� -	    �Name$ griid2��$��197,200,0,79q�$	��268��$	��155��.+��� -
    ��Name$ myCanvasBack��$	��150��$	��150��$
��Left=�$	��Top=�.+�'  !SharpVectors.Converters.SvgCanvas  -   	  Name$	 resourceSvgCanvasBack��

 �� Top$
 -1��$	��476��$
��Left=�$	��Top=��� -   $$��Сохранить в файл��$
��Left=�$��109,450,0,0q�$	��Top=�$	��120��$��26�����	#FF209BE0
���������Z� � -   $ griid��$��197,31,0,248q�$	��268��$	��155��.+��� -   $ myCanvasFront��$	��150��$	��150��$
��Left=�$	��Top=� K� ZIndex$	 100��.+��� -    ��Name$ myCanvasLabel1�����#3C3C3B �� Left$ 96��$
 11��$%��Fonts/#Akzidenz-Grotesk Pro Med)�$��11(�$ 3���� -   $ myCanvasLabel2�����#3C3C3B$ 96��$
 25��$%��Fonts/#Akzidenz-Grotesk Pro Med)�$��11(�$ 3���� -   $ myCanvasLabel3�����#3C3C3B$ 96��$
 41��$��Fonts/#Myriad Pro)�$��8(�$ 3���� -   $ myCanvasLabel4�����#3C3C3B$ 96��$
 55��$��Fonts/#Myriad Pro)�$��7(�$ 3���� -   $ myCanvasLabel5�����#3C3C3B$ 96��$
 63��$��Fonts/#Myriad Pro)�$��7(�$ 3���� -   $ myCanvasLabel6�����#3C3C3B$ 96��$
 72��$��Fonts/#Myriad Pro)�$��7(�$ 3���� -   $ myCanvasLabel7�����#3C3C3B$ 96��$
 50��$��Fonts/#Myriad Pro)�$��7(�$ 3��  -   $	 resourceSvgCanvasFront��$	��164��$	��156��$
 -1��$y�Visible=� J� Opacity$ 1Q��� -    ��Name$
 img1��$��70��$��70��$ 20��$
 18��$�� ���� -    ��Name$ scaler��$
��Left=�$��109,371,0,0q�$	��Top=�$	��120�� � Minimum$ 1Q� � SmallChange$
 0.05Q� � Value$ 1Q�$y�	Collapsed=��� $��Масштаб��$
��Left=�$��
30,367,0,0q�$	��Top=�$y�	Collapsed=��� -   $
��Left=�$��
60,255,0,0q�$�� ��$
 Wrap=�$	��Top=�$	��169��$��40���� $E��?Уч. степень/звание (не обязательно)��$
��Left=�$��
30,225,0,0q�$	��Top=�