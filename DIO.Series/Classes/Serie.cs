using System;

namespace DIO.Series
{
    public class Serie : BaseEntity {
        // Atributes
        private Genre Genre {get; set;}
        private string Title {get; set;}
        private string Description {get; set;}
        private int Year {get; set;}
		private bool Deleted {get; set;}

        public Serie(int id, Genre genre, string title, string description, int year)
		{
			this.Id = id;
			this.Genre = genre;
			this.Title = title;
			this.Description = description;
			this.Year= year;
			this.Deleted = false;
		}

        public override string ToString()
		{
            string return_str = "";
            return_str += "Genre: " + this.Genre + Environment.NewLine;
            return_str += "Title: " + this.Title + Environment.NewLine;
            return_str += "Description: " + this.Description + Environment.NewLine;
            return_str += "Year: " + this.Year + Environment.NewLine;
			return_str += "Deleted: " + this.Deleted + Environment.NewLine;
            
			return return_str;
		}
        public string returnTitle()
		{
			return this.Title;
		}

		public int returnId()
		{
			return this.Id;
		}

		public bool returnDeleted()
		{
			return this.Deleted;
		}

		public void Delete() {
            this.Delete = true;
        }
    }
}