namespace BackendTestWork.Helpers
{
    public class ExerciseTree
    {
		internal class TreeMaker
		{
			List<Nodo> nodos = new List<Nodo>{
			new Nodo{
				Id = 0,
				Nombre = "Raíz",
			},
			new Nodo{
				Id = 1,
				Nombre = "Hijo 1 Padre 0",
				PadreId = 0
			},
			new Nodo{
				Id = 2,
				Nombre = "Hijo 2 Padre 0",
				PadreId = 0
			},
			new Nodo{
				Id = 3,
				Nombre = "Hijo 3 Padre 0",
				PadreId = 0
			},
			new Nodo{
				Id = 4,
				Nombre = "Hijo 4 Padre 1",
				PadreId = 1
			},
			new Nodo{
				Id = 5,
				Nombre = "Hijo 5 Padre 4",
				PadreId = 4
			},
			new Nodo{
				Id = 6,
				Nombre = "Hijo 6 Padre 2",
				PadreId = 2
			},
			new Nodo{
				Id = 7,
				Nombre = "Hijo 7 Padre 2",
				PadreId = 2
			},
			new Nodo{
				Id = 8,
				Nombre = "Hijo 8 Padre 3",
				PadreId = 3
			},
			new Nodo{
				Id = 9,
				Nombre = "Hijo 9 Padre 1",
				PadreId = 1
			}
		};

		public List<Nodo> TreeGenerator()
			{
				List<Nodo> arbol = new List<Nodo>();
				// Code goes here
				return arbol;
			}

		}

		internal class Nodo
		{
			public int Id { get; set; }

			public string Nombre { get; set; }

			public int? PadreId { get; set; }

			public List<Nodo> hijos { get; set; }
		}
	}
}
