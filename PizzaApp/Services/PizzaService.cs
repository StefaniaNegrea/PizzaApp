using PizzaApp.Models;


namespace PizzaApp.Services
{
    public class PizzaService
    {
        private readonly static IEnumerable<Pizza> _pizzas = new
            List<Pizza>
        {
               new Pizza { Name = "Margherita", Image = "pizza1.png", Price = 20.99 },
               new Pizza { Name = "Calzone", Image = "pizza2.png", Price = 21.99 },
               new Pizza { Name = "Pepperoni", Image = "pizza3.png", Price = 22.99 },
               new Pizza { Name = "Prosciutto e funghi", Image = "pizza4.png", Price = 23.99 },
               new Pizza { Name = "Quattro Stagione", Image = "pizza5.png", Price = 24.99 },
               new Pizza { Name = "Margerita", Image = "pizza6.png", Price = 25.99 },
               new Pizza { Name = "Diavola", Image = "pizza7.png", Price = 26.99 },
               new Pizza { Name = "Frutti di Mare", Image = "pizza8.png", Price = 27.99 },
               new Pizza { Name = "Napoletana", Image = "pizza9.png", Price = 28.99 },
               new Pizza { Name = "Capricciosa", Image = "pizza10.png", Price = 29.99 }
        };

        public  IEnumerable<Pizza> GetAllPizzas() => _pizzas;

        public  IEnumerable<Pizza> GetPopularPizzas(int count = 6) =>
            _pizzas.OrderBy(p => Guid.NewGuid())
            .Take(count);

        public  IEnumerable<Pizza> SearchPizzas(string searchTerm) =>
            string.IsNullOrWhiteSpace(searchTerm)
            ? _pizzas
            : _pizzas.Where(p => p.Name.Contains(searchTerm,
                StringComparison.OrdinalIgnoreCase));
    }
}
