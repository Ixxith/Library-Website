using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Website.Models
{
    // Used to Seed Database with data
    public class SeedData
    {
        // Function to check if the database is populated
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            // Get context
            BookDBContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookDBContext>();

          
            // Check if migrations need to be applied
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            // Check if there are any books
            if(!context.books.Any())
            {// Add multiple book objects
                context.books.AddRange(

                    new Book
                    {
                        
                        Author = "Victor Hugo",
                        Title = "Les Miserables",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        Pages = 1488

                    },

                     new Book
                    {
                        
                        Author = "Doris Kearns Goodwin",
                        Title = "Team of Rivals",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                        Pages = 944

                     },

                      new Book
                      {

                          Author = "Alice Schroeder",
                          Title = "The Snowball",
                          Publisher = "Bantam",
                          ISBN = "978-0553384611",
                          Classification = "Non-Fiction",
                          Category = "Biography",
                          Price = 21.54,
                          Pages = 832

                      },

                       new Book
                       {

                           Author = "Ronald C. White",
                           Title = "American Ulysses",
                           Publisher = "Random House",
                           ISBN = "978-0812981254",
                           Classification = "Non-Fiction",
                           Category = "Biography",
                           Price = 11.61,
                           Pages = 864

                       },

                        new Book
                        {

                            Author = "Laura Hillenbrand",
                            Title = "Unbroken",
                            Publisher = "Random House",
                            ISBN = "978-0812974492",
                            Classification = "Non-Fiction",
                            Category = "Historical",
                            Price =13.33,
                            Pages = 528

                        },

                         new Book
                         {

                             Title = "The Great Train Robbery",
                             Author = "Michael Crichton",
                             Publisher = "Vintage",
                             ISBN = "978-0804171281",
                             Classification = "Fiction",
                             Category = "Historical Fiction",
                             Price = 15.95,
                             Pages = 288

                         },

                          new Book
                          {

                              Author = "Cal Newport",
                              Title = "Deep Work",
                              Publisher = "Grand Central Publishing",
                              ISBN = "978-1455586691",
                              Classification = "Non-Fiction",
                              Category = "Self-Help",
                              Price = 14.99,
                              Pages = 304

                          },

                           new Book
                           {

                               Author = "Michael Abrashoff",
                               Title = "It's Your Ship",
                               Publisher = "Grand Central Publishing",
                               ISBN = "978-1455523023",
                               Classification = "Non-Fiction",
                               Category = "Self-Help",
                               Price = 21.66,
                               Pages = 240

                           },

                            new Book
                            {

                                Title = "The Virgin Way",
                                Author = "Richard Branson",
                                Publisher = "Portfolio",
                                ISBN = "978-1591847984",
                                Classification = "Non-Fiction",
                                Category = "Business",
                                Price = 29.16,
                                Pages = 944

                            },

                             new Book
                             {

                                 Author = "John Grisham",
                                 Title = "Sycamore Row",
                                 Publisher = "Bantam",
                                 ISBN = "978-0553393613",
                                 Classification = "Fiction",
                                 Category = "Thrillers",
                                 Price = 15.03,
                                 Pages = 642

                            },

                             // Add the three new books

                             new Book
                             {

                                 Author = "Brandon Sanderson",
                                 Title = "Mistborn",
                                 Publisher = "Tor Books",
                                 ISBN = "978-0765360960",
                                 Classification = "Fiction",
                                 Category = "Fantasy",
                                 Price = 24.44,
                                 Pages = 672

                             },

                            new Book
                            {

                                Author = "Stephen Covey",
                                Title = "The 7 Habits of Highly Effective People",
                                Publisher = "Free Press",
                                ISBN = "978-0743269519",
                                Classification = "Non-Fiction",
                                Category = "Self-Help",
                                Price = 28.99,
                                Pages = 384

                            },

                            new Book
                            {

                                Author = "Glen Cook",
                                Title = "The Black Company",
                                Publisher = "Tor Books",
                                ISBN = "978-0812521399",
                                Classification = "Fiction",
                                Category = "Fantasy",
                                Price = 8.91,
                                Pages = 320

                            }

                );
                // Save the changes to the database
                context.SaveChanges();
            }
        }
    }
}
