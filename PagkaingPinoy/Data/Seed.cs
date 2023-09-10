using PagkaingPinoy.Models;

namespace PagkaingPinoy.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Menus.Any())
                {
                    context.Menus.AddRange(new List<Menu>()
                    {
                        //Starter
                        new Menu()
                        {
                            Category = "Starter",
                            DishName = "Empada",
                            DishAbbreviation = "EMP",
                            Description = "Fried pastry filled with meat, egg, vegetables, and, sweet and chili sauce.",
                            Price = 100
                        },

                        new Menu()
                        {
                            Category = "Starter",
                            DishName = "Lumpiang Shanghai",
                            DishAbbreviation = "LSH",
                            Description = "Spring rools stuffed with ground pork, carrots, kinchay, and spices.",
                            Price = 80
                        },

                        new Menu()
                        {
                            Category = "Starter",
                            DishName = "Okoy",
                            DishAbbreviation = "OKY",
                            Description = "Fried small shrimp with papaya that binded using egg.",
                            Price = 100
                        },

                        //Main
                        new Menu()
                        {
                            Category = "Main",
                            DishName = "Adobo",
                            DishAbbreviation = "ADB",
                            Description = "A Filipino traditional chicken dish that cooked in soy sauce and vinegar.",
                            Price = 325
                        },

                        new Menu()
                        {
                            Category = "Main",
                            DishName = "Tinola",
                            DishAbbreviation = "TNL",
                            Description = "A traditional Filipino comfort food that consist of broth, chicken, leafy greens, papaya, and ginger.",
                            Price = 300
                        },

                        new Menu()
                        {
                            Category = "Main",
                            DishName = "Sinigang",
                            DishAbbreviation = "SNG",
                            Description = "A Filipino soup characterized by its sour and savory taste. A chicken dish cooked in samapalok(tamarind).",
                            Price = 350
                        },

                        //Side Dish
                        new Menu()
                        {
                            Category = "SideDish",
                            DishName = "Atsara",
                            DishAbbreviation = "ATS",
                            Description = "Atchara, also known as atsara or achara, is a well-known Filipino pickled condiment made from unripe, green papaya.",
                            Price = 160
                        },

                        new Menu()
                        {
                            Category = "SideDish",
                            DishName = "Ensaladang Talong",
                            DishAbbreviation = "ETL",
                            Description = "A Filipino side dish composed of cooked mashed eggplant, fresh tomato, and onion with vinegar.",
                            Price = 140
                        },

                        new Menu()
                        {
                            Category = "SideDish",
                            DishName = "Bagoong",
                            DishAbbreviation = "BNG",
                            Description = "Bagoong or alamang is a fermented condiment made of minute shrimp or krill.",
                            Price = 120
                        },

                        //Dessert
                        new Menu()
                        {
                            Category = "Dessert",
                            DishName = "Halo-Halo",
                            DishAbbreviation = "HAL",
                            Description = "A Filipino famous dessert that means \"mix-mix.\". It is composed of shaved ice, toasted pinipigs, Saba bananas, chewy nata de coco, milk, and other add ons.",
                            Price = 180
                        },

                        new Menu()
                        {
                            Category = "Dessert",
                            DishName = "Leche Plan",
                            DishAbbreviation = "LPN",
                            Description = "Leche Flan is a dessert made-up of eggs and milk with a soft caramel on top. It resembles crème caramel and caramel custard.",
                            Price = 220
                        },

                        new Menu()
                        {
                            Category = "Dessert",
                            DishName = "Buko Salad",
                            DishAbbreviation = "BSD",
                            Description = "Buko Salad or sweet young coconut salad is a dessert dish that makes use of shredded young coconut as the main ingredient.",
                            Price = 260
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
