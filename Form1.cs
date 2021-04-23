using System;
using System.Windows.Forms;

namespace PR5
{
    public partial class Form1 : Form
    {
        static int[] mass = { 6, 8, 9, 2, 1, 3, 5, 4, 7 };
        string type_of_sort = "Обменом";
        private void sort()
        {
            check_mass();
            switch (type_of_sort)
            {
                case "Обменом":
                    richTextBox1.Text = "Обменом\n";
                    GnomeSort(mass);
                    break;
                case "Выбором":
                    richTextBox2.Text = "Выбором\n";
                    SelectSort(mass);
                    break;
                case "Вставками":
                    richTextBox3.Text = "Вставками\n";
                    InsertSort(mass);
                    break;
                case "Пузырьком":
                    richTextBox4.Text = "Пузырьком\n";
                    BubbleSort(mass);
                    break;
                case "Быстрая":
                    richTextBox5.Text = "Быстрая\n";
                    QSort(mass,0,mass.Length-1,0);
                    break;

            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sort();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            type_of_sort = tabControl1.SelectedTab.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            check_mass();
        }
        private void check_mass()
        {
            string[] mass_str = textBox1.Text.Split(" ");
            mass = new int[mass_str.Length];
            for (int i = 0; i < mass_str.Length; i++)
            {
                mass[i] = Convert.ToInt32(mass_str[i]);
            }
        }
        static string WriteArray(int[] a, int iteration)
        {
            string arr = "\n"+iteration.ToString() + " итерация\n";
            foreach (int k in a)
            {
                arr += k + " ";
            }
            return arr+"\n";
        }
        private void GnomeSort(int[] a) // edit for this project
        {
            int iteration = 0;
            int i = 1;
            int j = 2;
            while (i < a.Length)
            {
                if (a[i - 1] < a[i])
                {
                    i = j;
                    j = j + 1;
                }
                else
                {
                    Swap(a, i - 1, i);
                    i = i - 1;
                    if (i == 0)
                    {
                        i = j;
                        j = j + 1;
                    }
                }
                richTextBox1.Text += WriteArray(a, ++iteration);
            }
        }

        private void SelectSort(int[] a) // edit for this project
        {
            int iteration = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[min])
                    {
                        min = j;
                    }
                }
                int k = a[i];
                a[i] = a[min];
                a[min] = k;
                richTextBox2.Text += WriteArray(a, ++iteration);
            }
        }

        private void InsertSort(int[] a) // edit for this project
        {
            int iteration = 0;
            for (int i = 1; i < a.Length; i++)
            {
                
                int k = a[i];
                int j = i;
                while (j > 0 && k < a[j - 1])
                {
                    a[j] = a[j - 1];
                    j--;
                }
                a[j] = k;
                richTextBox3.Text += WriteArray(a, ++iteration);
            }
        }
        private void BubbleSort(int[] a) // edit for this project
        {
            int iteration = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        int o = a[i];
                        a[i] = a[j];
                        a[j] = o;
                    }
                }
                richTextBox4.Text += WriteArray(a, ++iteration);
            }
        }
        private void QSort(int[] arr, int l, int r, int iteration) // edit for this project
        {
            int _iteration = iteration++;
            int i = l;
            int j = r;
            int x = arr[(l + r) / 2];
            while (i <= j)
            {
                while (arr[i] < x) i++;
                while (arr[j] > x) j--;
                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
                richTextBox5.Text += WriteArray(arr, ++_iteration);
            }
            if (l < j) QSort(arr, l, j, _iteration);
            if (i < r) QSort(arr, i, r, _iteration);
        }
        static void Swap(int[] a, int i, int j)
        {
            int g = a[i];
            a[i] = a[j];
            a[j] = g;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
