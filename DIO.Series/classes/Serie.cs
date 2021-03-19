using System;

namespace DIO.Series
{
    public class Serie : BaseEntity {
        // Atributes
        private Genre Genre {get; set;}
        private string Title {get; set;}
        private string Description {get; set;}
        private int Year {get; set;}

        public Serie(int id, Genre genre, string title, string description, int year)
		{
			this.Id = id;
			this.Genre = genre;
			this.Title = title;
			this.Description = description;
			this.Year= year;
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Gênero: " + this.Genre + Environment.NewLine;
            retorno += "Titulo: " + this.Title + Environment.NewLine;
            retorno += "Descrição: " + this.Description + Environment.NewLine;
            retorno += "Ano de Início: " + this.Year + Environment.NewLine;
            
			return retorno;
		}
        public string returnTitle()
		{
			return this.Title;
		}

		public int returnId()
		{
			return this.Id;
		}
    }
}