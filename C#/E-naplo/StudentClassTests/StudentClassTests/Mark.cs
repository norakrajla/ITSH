using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass
{
    public class Mark
    {
        public int Grade { get; set; }
        public Subject Subject { get; set; }
        
        public DateTime Date { get; set; }

        public Mark(int grade, Subject subjectName)
        {
            this.Grade = grade;
            this.Subject = subjectName;

            if (subjectName is null)
            {
                throw new ArgumentNullException("Nem írtál be tantárgyat te kis buta!");
            }
        }

        public override string ToString()
        {
            string jegySzoveggel = "";
            
            switch (Grade)
            {
                case 5:
                    jegySzoveggel = "excellent(5)";
                    break;
                case 4:
                    jegySzoveggel = "very good(4)";
                    break;
                case 3:
                    jegySzoveggel = "satisfactory(3)";
                    break;
                case 2:
                    jegySzoveggel = "borderline(2)";
                    break;
                case 1:
                    jegySzoveggel = "failed(1)";
                    break;
            }

            return jegySzoveggel;
        }

    }
}
