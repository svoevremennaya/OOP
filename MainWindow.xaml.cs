using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.IO;
using Path = System.IO.Path;
using System.Runtime.Serialization;

namespace lab_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        object[] Parameters = new object[10];
        public List<UIElement> Components = new List<UIElement>();
        [DataMember] public List<Technic> TechnicObjects = new List<Technic>();
        public Dictionary<string, Creator> Factories = new Dictionary<string, Creator>();
        public static Type[] typeObjList;

        BinarySerialization binarySerialization = new BinarySerialization();
        XMLSerialization XMLSerialization = new XMLSerialization();

        public MainWindow()
        {
            InitializeComponent();
            accept_edit.IsEnabled = false;
            AddComponents();

            Assembly assembly = Assembly.Load("lab_2");
            Type[] type = assembly.GetTypes();
            GenerateFactoryList(type);

            List<Type> typeList = new List<Type>();
            foreach (Type item in type)
            {
                if (item.IsSubclassOf(typeof(Technic)))
                {
                    typeList.Add(item);
                }
            }

            typeObjList = new Type[typeList.Count];
            for (int i = 0; i < typeList.Count; i++)
            {
                typeObjList[i] = typeList[i];
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput())
            {
                GenerateParametersList();
                AddObject();
                ClearComponents();
            }
            else
            {
                MessageBox.Show("Incorrect data");
            }
        }

        //Adds object to list of objects
        private void AddObject()
        {
            foreach (string item in Factories.Keys)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)classes.SelectedItem;
                if (item == selectedItem.Content.ToString())
                {
                    TechnicObjects.Add(Factories[item].FactoryMethod(Parameters));
                    AddToListBox(Factories[item].Img, TechnicObjects.Count - 1);
                }
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteObject();
            ClearComponents();
        }

        //Deletes object from list of objects
        private void DeleteObject()
        {
            if (objects_lb.SelectedIndex != -1)
            {
                TechnicObjects.RemoveAt(objects_lb.SelectedIndex);
                objects_lb.Items.Clear();

                for (int i = 0; i < TechnicObjects.Count; i++)
                {
                    Type objectType = TechnicObjects[i].GetType();
                    AddToListBox(Factories[Convert.ToString(objectType.Name)].Img, i);
                }
            }
        }

        private void AddComponents()
        {
            Components.Add(year_production);
            Components.Add(brand_tb);
            Components.Add(price_tb);
            Components.Add(use_vol);
            Components.Add(num_compr);
            Components.Add(proc);
            Components.Add(mem);
            Components.Add(sim);
            Components.Add(screen);
            Components.Add(cam);
            Components.Add(num);
        }

        private void GenerateParametersList()
        {
            int i = 0;
            foreach (UIElement item in Components)
            {
                if (item.IsEnabled)
                {
                    if ((item == year_production) || (item == proc) || (item == sim))
                    {
                        ComboBoxItem selectedItem = (ComboBoxItem)(((ComboBox)item).SelectedItem);
                        Parameters[i] = selectedItem.Content.ToString();
                        i++;
                    }
                    else if ((item == cam) || (item == num))
                    {
                        Parameters[i] = ((CheckBox)item).IsChecked;
                        i++;
                    }
                    else
                    {
                        Parameters[i] = ((TextBox)item).Text;
                        i++;
                    }
                }
            }
        }

        private void GenerateFactoryList(Type[] type)
        {
            foreach (Type item in type)
            {
                if (item.IsSubclassOf(typeof(Creator)))
                {
                    Factories.Add((item.Name).Substring(0, Math.Abs((item.Name).IndexOf("Creator"))), (Creator)Activator.CreateInstance(item));
                }
            }
        }

        private void ClearComponents()
        {
            foreach (UIElement item in Components)
            {
                if ((item == year_production) || (item == proc) || (item == sim))
                {
                    ((ComboBox)item).SelectedIndex = -1;
                }
                else if ((item == cam) || (item == num))
                {
                    ((CheckBox)item).IsChecked = false;
                }
                else
                {
                    ((TextBox)item).Clear();
                }
            }
            classes.SelectedIndex = -1;
        }

        private void ComboBox_Selected(object sender, SelectionChangedEventArgs e)
        {
            EnableComponents();
        }

        private void EnableComponents()
        {
            switch (classes.SelectedIndex)
            {
                //fridge
                case 0:
                    use_vol.IsEnabled = true;
                    num_compr.IsEnabled = true;
                    proc.IsEnabled = false;
                    mem.IsEnabled = false;
                    sim.IsEnabled = false;
                    screen.IsEnabled = false;
                    cam.IsEnabled = false;
                    num.IsEnabled = false;
                    break;

                //laptop
                case 1:
                    use_vol.IsEnabled = false;
                    num_compr.IsEnabled = false;
                    proc.IsEnabled = true;
                    mem.IsEnabled = true;
                    sim.IsEnabled = false;
                    screen.IsEnabled = false;
                    cam.IsEnabled = false;
                    num.IsEnabled = true;
                    break;

                //smartphone
                case 2:
                    use_vol.IsEnabled = false;
                    num_compr.IsEnabled = false;
                    proc.IsEnabled = true;
                    mem.IsEnabled = true;
                    sim.IsEnabled = true;
                    screen.IsEnabled = true;
                    cam.IsEnabled = false;
                    num.IsEnabled = false;
                    break;

                //button_phone
                case 3:
                    use_vol.IsEnabled = false;
                    num_compr.IsEnabled = false;
                    proc.IsEnabled = true;
                    mem.IsEnabled = true;
                    sim.IsEnabled = true;
                    screen.IsEnabled = false;
                    cam.IsEnabled = true;
                    num.IsEnabled = false;
                    break;
            }
        }

        private void AddToListBox(string Img, int Element)
        {
            StackPanel stackPanel = new StackPanel { Width = 370, Height = 150 };
            stackPanel.Orientation = Orientation.Horizontal;

            stackPanel.Children.Add(new Image
            {
                Source = new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "Images/", Img))),
                Width = 100,
                Height = 100,
            });

            Label label = new Label { Width = 260  };
            label.Content = TechnicObjects[Element].PrintInfo();
            stackPanel.Children.Add(label);
            objects_lb.Items.Add(stackPanel);
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            add.IsEnabled = false;
            delete.IsEnabled = false;
            edit.IsEnabled = false;
            accept_edit.IsEnabled = true;
            serialize.IsEnabled = false;
            deserialize.IsEnabled = false;

            if (objects_lb.SelectedIndex != -1)
            {
                LoadObject(TechnicObjects[objects_lb.SelectedIndex]);
            }
        }

        private void LoadObject(Technic obj)
        {
            classes.Text = (Convert.ToString(obj.GetType())).Substring(6);
            Object[] fields = obj.GetFields();
            int i = 0;
            
            foreach(UIElement item in Components)
            {
                if (item.IsEnabled)
                {
                    if ((item == year_production) || (item == proc) || (item == sim))
                    {
                        ((ComboBox)item).Text = Convert.ToString(fields[i]);
                        i++;
                    }
                    else if ((item == cam) || (item == num))
                    {
                        ((CheckBox)item).IsChecked = (bool)fields[i];
                        i++;
                    }
                    else
                    {
                        ((TextBox)item).Text = Convert.ToString(fields[i]);
                        i++;
                    }
                }
            }
        }

        private void accept_edit_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput())
            {
                add.IsEnabled = true;
                delete.IsEnabled = true;
                edit.IsEnabled = true;
                accept_edit.IsEnabled = false;
                serialize.IsEnabled = true;
                deserialize.IsEnabled = true;

                GenerateParametersList();
                TechnicObjects[objects_lb.SelectedIndex].FillFields(Parameters);
                objects_lb.Items.Clear();

                for (int i = 0; i < TechnicObjects.Count; i++)
                {
                    Type objectType = TechnicObjects[i].GetType();
                    AddToListBox(Factories[Convert.ToString(objectType.Name)].Img, i);
                }

                ClearComponents();
            }
            else
            {
                MessageBox.Show("Incorrect data");
            }
        }

        private void serialize_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)binary.IsChecked)
            {
                binarySerialization.Serialize(TechnicObjects);
            }
            else if ((bool)xml.IsChecked)
            {
                XMLSerialization.Serialize(TechnicObjects);
            }
            else
            {
                MessageBox.Show("Binary or XML???");
            }
        }

        private void deserialize_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)binary.IsChecked)
            {
                TechnicObjects = binarySerialization.Deserialize();
                objects_lb.Items.Clear();

                for (int i = 0; i < TechnicObjects.Count; i++)
                {
                    Type objectType = TechnicObjects[i].GetType();
                    AddToListBox(Factories[Convert.ToString(objectType.Name)].Img, i);
                }

            }
            else if ((bool)xml.IsChecked)
            {
                TechnicObjects = XMLSerialization.Deserialize();
                objects_lb.Items.Clear();

                for (int i = 0; i < TechnicObjects.Count; i++)
                {
                    Type objectType = TechnicObjects[i].GetType();
                    AddToListBox(Factories[Convert.ToString(objectType.Name)].Img, i);
                }
            }
            else
            {
                MessageBox.Show("Binary or XML???");
            }
        }

        private bool CheckInput()
        {
            try
            {
                if (classes.SelectedIndex == -1)
                    return false;
                Convert.ToInt32(price_tb.Text);
                if (use_vol.IsEnabled)
                    Convert.ToInt32(use_vol.Text);
                if (num_compr.IsEnabled)
                    Convert.ToInt32(num_compr.Text);
                if (mem.IsEnabled)
                    Convert.ToInt32(mem.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
