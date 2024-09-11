// using Microsoft.EntityFrameworkCore;


// namespace CartTransactionService.Data
// {
//     public static class PrepDb
// {
    
//     public static void PrepPopulation(IApplicationBuilder app)
//     {
//         using (var serviceScope = app.ApplicationServices.CreateScope())
//         {
//             Migrate(serviceScope.ServiceProvider.GetService<CartDbContext>());
//         }
//     }

//     // This method performs the migration
//     private static void Migrate(CartDbContext context)
//     {
//         if (context != null)
//         {
//             context.Database.Migrate();
//         }
//     }
// }

// }