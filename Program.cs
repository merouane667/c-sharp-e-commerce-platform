using System;
using System.Collections.Generic;
namespace c__project

{
    class Program
    {
        // List of users and products
        public static List<User> users = new List<User>();
        public static List<Product> products = new List<Product>();
        public static List<Product> ProductsToPurchase = new List<Product>();
        public static List<Product> ProductsPurchased = new List<Product>();

        // List categories
        public static List<Category> categories = new List<Category>();


        // Current user
        public static User currentUser = null;

        // user Cart
        public static Cart Cart;

        // list of orders
        public static List<Order> orders = new List<Order>();
        
        // user payment method
        public static PaymentMethod PaymentMethod;

        // exit variables
        public static bool exit = false;
        public static string exitStatus;

        static void Main(string[] args)
        {
            //Generate Products
            GenerateProducts();

            //Generate Categories
            GenerateCategories();
            
            while (!exit)
            {
                Console.WriteLine("--- E-Commerce Platform ---");
                Console.WriteLine("1. Create new user");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Modify user profile");
                Console.WriteLine("4. Delete user profile");
                Console.WriteLine("5. Read products ( Admin Only )");
                Console.WriteLine("6. Create product ( Admin Only )");
                Console.WriteLine("7. Update product ( Admin Only )");
                Console.WriteLine("8. Delete product ( Admin Only )");
                Console.WriteLine("9. Read categories ( Admin Only )");
                Console.WriteLine("10. Create category ( Admin Only )");
                Console.WriteLine("11. Update category ( Admin Only )");
                Console.WriteLine("12. Delete category ( Admin Only )");
                Console.WriteLine("13. Add product to cart");
                Console.WriteLine("14. Empty or modify cart");
                Console.WriteLine("15. Add payment method");
                Console.WriteLine("16. Read payment method");
                Console.WriteLine("17. Update payment method");
                Console.WriteLine("18. Delete payment method");
                Console.WriteLine("19. Purchase cart's products");
                Console.WriteLine("20. Read purchase history from orders");
                Console.WriteLine("21. Re-buy product with old placed order");
                Console.WriteLine("22. Calculate total spent on products for user");
                Console.WriteLine("23. Calculate daily revenue from sales");
                Console.WriteLine("24. Calculate total price of product with tax");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        // Create new user
                        Console.Write("Enter user role ( Normal / Admin ): ");
                        string roleInput = Console.ReadLine();
                        int role = 1;
                        if (roleInput.ToLower() == "admin")
                        {
                            role = 0;
                        }
                        Console.Write("Enter full name: ");
                        string fullName = Console.ReadLine();
                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter phone number: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Enter address: ");
                        string address = Console.ReadLine();
                        User user = new User(users.Count + 1, role, fullName, email, phoneNumber, address, null, 0, new List<Product>());
                        users.Add(user);
                        currentUser = user;
                        Console.WriteLine("User created successfully!");
                        Console.WriteLine(currentUser.GetFullName()+" You're now logged in!");
                        //continue?
                        Console.Write("Do you want to continue ( No / Yes ): ");
                        exitStatus = Console.ReadLine();
                        if (exitStatus.ToLower() == "no")
                        {
                            exit = true;
                        }
                        break; 
                    case 2:
                        //login
                        Console.Write("Enter email: ");
                        string emailToFind = Console.ReadLine();
                        foreach (var userToFind in users)
                        {
                            if (userToFind.GetEmail() == emailToFind)
                            {
                                currentUser = userToFind;
                                Console.WriteLine(currentUser.GetFullName()+" You're now logged in!");
                                break;
                            }
                        }
                        if (users.Count == 0)
                        {
                            Console.WriteLine("no account was found!");
                            DYWToContinue();
                            break;
                        }else{
                            if (currentUser.GetEmail() == emailToFind)
                            {
                                DYWToContinue();
                                break;
                            }else{
                                Console.WriteLine("no account was found!");
                                DYWToContinue();
                                break;
                            }
                        }

                    case 3:
                        // Modify user profile
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;

                        }else{
                            Console.Write("Enter user role ( Normal / Admin ): ");
                            string NewRoleInput = Console.ReadLine();
                            int NewRole = 0;
                            if (NewRoleInput.ToLower() == "admin")
                            {
                                NewRole = 1;
                            }
                            Console.Write("Enter full name: ");
                            string NewFullName = Console.ReadLine();
                            Console.Write("Enter email: ");
                            string NewEmail = Console.ReadLine();
                            Console.Write("Enter phone number: ");
                            string NewPhoneNumber = Console.ReadLine();
                            Console.Write("Enter address: ");
                            string NewAddress = Console.ReadLine();
                            string NewRoleString = NewRole == 1 ? "admin" : "normal";

                            currentUser.SetChosenRole(NewRoleString);
                            currentUser.SetFullName(NewFullName);
                            currentUser.SetEmail(NewEmail);
                            currentUser.SetPhoneNumber(NewPhoneNumber);
                            currentUser.SetAddress(NewAddress);
                            Console.WriteLine(currentUser.GetFullName()+"'s Profile modified successfully!");
                            DYWToContinue();
                        }
                        break;

                    case 4:
                        //Delete user
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;
                        }else{
                            for (int i = users.Count-1; i >=0; i--)
                            {
                                if (users[i].GetId() == currentUser.GetId())
                                {
                                    users.RemoveAt(i);
                                    Console.WriteLine("User deleted successfully!");
                                }
                            }
                            currentUser = null;
                            DYWToContinue();

                            break;
                        }
                    case 5:
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;
                        }else{
                            if (currentUser.GetChosenRole() == "Normal")
                            {
                                Console.WriteLine("You are not an admin user!");
                                DYWToContinue();
                                break;  
                            }else{
                                //Read All available products in stock
                                PrintProductList();
                            }
                        }
                        DYWToContinue(); 
                        break;
                    case 6:
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;  
                        }else{

                            if (currentUser.GetChosenRole() == "Normal")
                            {
                                Console.WriteLine("You are not an admin user!");
                                DYWToContinue();
                                break;  
                            }else{
                                CreateProduct();
                                Console.WriteLine("Product added successfully!");
                                DYWToContinue();
                                break;  
                            }
                        }
                    case 7:
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;  
                        }else{

                            if (currentUser.GetChosenRole() == "Normal")
                            {
                                Console.WriteLine("You are not an admin user!");
                                DYWToContinue();
                                break;  
                            }else{
                                PrintProductList();
                                Console.WriteLine("Choose the product to update ( enter the Id ) :");
                                int IdProduct = Convert.ToInt32(Console.ReadLine());
                                UpdateProduct(IdProduct);
                                Console.WriteLine("Product updated successfully!");
                                DYWToContinue();
                                break;  
                            }
                        }                   
                    case 8:
                        //delete product
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;  
                        }else{

                            if (currentUser.GetChosenRole() == "Normal")
                            {
                                Console.WriteLine("You are not an admin user!");
                                DYWToContinue();
                                break;  
                            }else{
                                PrintProductList();
                                Console.WriteLine("Choose the product to delete ( enter the Id ) :");
                                int IdProduct = Convert.ToInt32(Console.ReadLine());
                                DeleteProduct(IdProduct);
                                Console.WriteLine("Product deleted successfully!");
                                DYWToContinue();
                                break;  
                            }
                        }
                    case 9:
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;
                        }else{
                            if (currentUser.GetChosenRole() == "Normal")
                            {
                                Console.WriteLine("You are not an admin user!");
                                DYWToContinue();
                                break;  
                            }else{
                                //Read All categories
                                PrintCategoryList();
                            }
                        }
                        DYWToContinue(); 
                        break;
                    case 10:
                        //add category
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;  
                        }else{

                            if (currentUser.GetChosenRole() == "Normal")
                            {
                                Console.WriteLine("You are not an admin user!");
                                DYWToContinue();
                                break;  
                            }else{
                                CreateCategory();
                                Console.WriteLine("category added successfully!");
                                DYWToContinue();
                                break;  
                            }
                        }
                    case 11:
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;  
                        }else{

                            if (currentUser.GetChosenRole() == "Normal")
                            {
                                Console.WriteLine("You are not an admin user!");
                                DYWToContinue();
                                break;  
                            }else{
                                PrintCategoryList();
                                Console.WriteLine("Choose the category to update ( enter the Id ) :");
                                int IdCategory = Convert.ToInt32(Console.ReadLine());
                                UpdateCategory(IdCategory);
                                Console.WriteLine("Category updated successfully!");
                                DYWToContinue();
                                break;  
                            }
                        }  
                    case 12:
                        //delete Category
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;  
                        }else{

                            if (currentUser.GetChosenRole() == "Normal")
                            {
                                Console.WriteLine("You are not an admin user!");
                                DYWToContinue();
                                break;  
                            }else{
                                PrintCategoryList();
                                Console.WriteLine("Choose the Category to delete ( enter the Id ) :");
                                int IdCategory = Convert.ToInt32(Console.ReadLine());
                                DeleteCategory(IdCategory);
                                Console.WriteLine("Category deleted successfully!");
                                DYWToContinue();
                                break;  
                            }
                        }
                    case 13:
                        //add product
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;
                        }else{
                            Boolean exitProductAddingBool = false;
                            ProductsToPurchase.Clear();
                            do
                            {
                                //Read All available products in stock
                                PrintProductList();
                                Console.WriteLine("Please choose the product to add to cart (enter the product Id) :");
                                int IdProduct = Convert.ToInt32(Console.ReadLine());
                                //Add product to cart 
                                AddProductToCart(IdProduct);
                                Console.WriteLine("Product added successfully!");

                                Console.WriteLine("do you want to add a nother product ? ( No / Yes ):");
                                string exitProductAdding = Console.ReadLine();
                                if (exitProductAdding.ToLower() == "no")
                                {
                                    exitProductAddingBool = true;
                                }
                            } while ( !exitProductAddingBool );
                            // Cart for the current user
                            float TotalTopay = TotalToPay();
                            Cart = new Cart(ProductsToPurchase, TotalTopay);
                        }
                        DYWToContinue(); 
                        break;
                    case 14:
                        if (ProductsToPurchase.Count>0)
                        {
                            PrintProductToPurchaseList();
                            Console.WriteLine("do you want to empty the cart or only delete one product ( empty / delete )");
                            string emportyOrDelete = Console.ReadLine();
                            if (emportyOrDelete.ToLower() == "empty")
                            {
                                ProductsToPurchase.Clear();
                                Cart.SetProducts(ProductsToPurchase);
                                Console.WriteLine("the cart was emptied!");
                                break;
                            }else{
                                Console.WriteLine("choose the product to delete ( enter the product Id ) :");
                                int IdProduct = Convert.ToInt32(Console.ReadLine());
                                PrintProductToPurchaseList();
                                for (int i = ProductsToPurchase.Count-1; i >=0; i--)
                                {
                                    if (ProductsToPurchase[i].GetId() == IdProduct)
                                    {
                                        ProductsToPurchase.RemoveAt(i);
                                        Cart.SetProducts(ProductsToPurchase);
                                        Console.WriteLine("Product deleted successfully!");
                                        DYWToContinue();
                                        break; 
                                    }
                                }
                                break;
                            }

                        }else if(currentUser != null){
                            Console.WriteLine("Your cart is empty!");
                            DYWToContinue(); 
                            break;                            
                        }else{
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;                          
                        }
                    case 15:
                        // add payment method
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;
                        }else{
                            AddPaymentMethod();
                            Console.WriteLine("Payment Method added successfully!");
                            DYWToContinue();
                            break;
                        }
                    case 16:
                        // Read payment method
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;
                        }else{
                            ReadPaymentMethod();
                            DYWToContinue();
                            break;
                        }

                    case 17:
                        // Update payment method
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;
                        }else{
                        UpdatePaymentMethod();
                        DYWToContinue();
                        break;
                        }
                    case 18:
                        // Delete payment method
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;
                        }else{
                            DeletePaymentMethod();
                            DYWToContinue();
                            break;
                        }

                    case 19:
                        // purchase cart's products
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;
                        }else{
                            PurchaseCartsProducts();
                            DYWToContinue();
                            break;
                        }
                    case 20:
                        // Read purchase history
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;
                        }else{

                            if (orders.Count == 0)
                            {
                                Console.WriteLine("the history is empty!");
                                DYWToContinue();
                                break;
                            }else{
                                Console.WriteLine("Purchase history : ");
                                foreach (var order in orders)
                                {
                                    foreach (var product in order.GetProducts()){

                                        Console.WriteLine("Id: " + product.GetId());
                                        Console.WriteLine("Name: " + product.GetName());
                                        Console.WriteLine("Description: " + product.GetDescription());
                                        Console.WriteLine("Price: " + product.GetPrice());
                                        Console.WriteLine("Category: " + product.GetCategory().GetName());
                                        Console.WriteLine("Reference: " + product.GetReference());
                                        Console.WriteLine("CreatedAt: " + product.GetCreatedAt());
                                        Console.WriteLine("NumberOfOrders: " + product.GetNumberOfOrders());
                                        Console.WriteLine("inStock: " + product.GetInStock());
                                        Console.WriteLine("----------------------------------------------");
                                    }

                                }
                                DYWToContinue();
                                break;
                            }
                        }
                    case 21:
                        // Re-buy product
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;
                        }else{
                            if (orders.Count == 0)
                            {
                                Console.WriteLine("You've never puchased a product before!");
                                DYWToContinue();
                                break;
                            }else{
                                Console.WriteLine("Here is the products that you already purchased :");
                                foreach (var order in orders)
                                {
                                    foreach (var product in order.GetProducts()){

                                        Console.WriteLine("Id: " + product.GetId());
                                        Console.WriteLine("Name: " + product.GetName());
                                        Console.WriteLine("Description: " + product.GetDescription());
                                        Console.WriteLine("Price: " + product.GetPrice());
                                        Console.WriteLine("Category: " + product.GetCategory().GetName());
                                        Console.WriteLine("Reference: " + product.GetReference());
                                        Console.WriteLine("CreatedAt: " + product.GetCreatedAt());
                                        Console.WriteLine("NumberOfOrders: " + product.GetNumberOfOrders());
                                        Console.WriteLine("inStock: " + product.GetInStock());
                                        Console.WriteLine("----------------------------------------------");
                                    }

                                }
                                Console.WriteLine("choose the product to re-buy ( enter the product Id ) :");
                                int IdProduct = Convert.ToInt32(Console.ReadLine());
                                AddProductToCart(IdProduct);
                                Console.WriteLine("Product added to cart successfuly!");
                                DYWToContinue();
                                break;
                            }
                        }
                    case 22:
                        // Calculate total spent on products for user
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;
                        }else{
                            if (orders.Count == 0)
                            {
                                Console.WriteLine("You've never puchased a product before!");
                                DYWToContinue();
                                break;
                            }else{
                                Console.WriteLine("Here is the total sent in each product you purchased:");
                                foreach (var order in orders)
                                {
                                    foreach (var product in order.GetProducts()){

                                        Console.WriteLine("Id: " + product.GetId());
                                        Console.WriteLine("Name: " + product.GetName());
                                        Console.WriteLine("Description: " + product.GetDescription());
                                        Console.WriteLine("Price: " + product.GetPrice());
                                        Console.WriteLine("Category: " + product.GetCategory().GetName());
                                        Console.WriteLine("Reference: " + product.GetReference());
                                        Console.WriteLine("CreatedAt: " + product.GetCreatedAt());
                                        Console.WriteLine("NumberOfOrders: " + product.GetNumberOfOrders());
                                        Console.WriteLine("inStock: " + product.GetInStock());
                                        Console.WriteLine("Total spent: " + product.GetPrice()*product.GetNumberOfOrders());
                                        Console.WriteLine("----------------------------------------------");
                                    }

                                }
                                DYWToContinue();
                                break;
                            }
                        }
                    case 23:
                        //Calculate daily revenue from sales
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;
                        }else{
                            if (orders.Count == 0)
                            {
                                Console.WriteLine("no product previously sold!");
                                DYWToContinue();
                                break;
                            }else{
                                float DailyRevenue = 0;
                                foreach (var order in orders)
                                        {
                                            foreach (var product in order.GetProducts())
                                            {
                                                DailyRevenue = DailyRevenue + product.GetPrice();
                                            }
                                        }
                                Console.WriteLine("The daily revenue is : "+DailyRevenue+" USD");
                                DYWToContinue();
                                break;
                            }
                        }

                    case 24:
                        //Calculate total price of product with tax
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in!");
                            DYWToContinue();
                            break;
                        }else{
                            PrintProductListTax();
                            DYWToContinue();
                            break;
                        }
                }
            }
        }


        //methods
        public static void GenerateProducts()
        {
            for (int i = 0; i < 10; i++)
            {
                int Id = i + 1; // Auto increment the ID
                string Name = "Product " + (i + 1);
                string Description = "Description for product " + (i + 1);
                float Price = (float)(i + 1) * 10.0f;
                Category Category = new Category(i + 1,"Category "+i + 1,"Description "+i + 1);
                string Reference = "ABC123";
                DateTime CreatedAt = DateTime.Now;
                int NumberOfOrders = 0;
                Boolean InStock = true;
                Product product = new Product( Id, Name,  Description, Price, Category,  Reference,  CreatedAt,  NumberOfOrders,  InStock);

                products.Add(product);
            }
            
        }

        public static void GenerateCategories()
        {
            for (int i = 0; i < 10; i++)
            {
                int Id = i + 1; // Auto increment the ID
                string Name = "Category " + (i + 1);
                string Description = "Description for category " + (i + 1);
                Category category = new Category( Id, Name,  Description );

                categories.Add(category);
            }
            
        }

        public static void PrintProductList()
        {
            foreach (var product in products)
            {
                Console.WriteLine("Id: " + product.GetId());
                Console.WriteLine("Name: " + product.GetName());
                Console.WriteLine("Description: " + product.GetDescription());
                Console.WriteLine("Price: " + product.GetPrice());
                Console.WriteLine("Category: " + product.GetCategory().GetName());
                Console.WriteLine("Reference: " + product.GetReference());
                Console.WriteLine("CreatedAt: " + product.GetCreatedAt());
                Console.WriteLine("NumberOfOrders: " + product.GetNumberOfOrders());
                Console.WriteLine("inStock: " + product.GetInStock());
                Console.WriteLine("----------------------------------------------");
            }
        }

        public static void PrintCategoryList()
        {
            foreach (var category in categories)
            {
                Console.WriteLine("Id: " + category.GetId());
                Console.WriteLine("Name: " + category.GetName());
                Console.WriteLine("Description: " + category.GetDescription());
                Console.WriteLine("----------------------------------------------");
            }
        }
        
        public static void PrintProductListTax()
        {
            foreach (var product in products)
            {
                Console.WriteLine("Id: " + product.GetId());
                Console.WriteLine("Name: " + product.GetName());
                Console.WriteLine("Description: " + product.GetDescription());
                Console.WriteLine("Price including taxes: " + (product.GetPrice()+(product.GetPrice()*0.2f)));
                Console.WriteLine("Category: " + product.GetCategory().GetName());
                Console.WriteLine("Reference: " + product.GetReference());
                Console.WriteLine("CreatedAt: " + product.GetCreatedAt());
                Console.WriteLine("NumberOfOrders: " + product.GetNumberOfOrders());
                Console.WriteLine("inStock: " + product.GetInStock());
                Console.WriteLine("----------------------------------------------");
            }
        }
        public static void PrintProductToPurchaseList()
        {
            foreach (var product in ProductsToPurchase)
            {
                Console.WriteLine("Id: " + product.GetId());
                Console.WriteLine("Name: " + product.GetName());
                Console.WriteLine("Description: " + product.GetDescription());
                Console.WriteLine("Price: " + product.GetPrice());
                Console.WriteLine("Category: " + product.GetCategory().GetName());
                Console.WriteLine("Reference: " + product.GetReference());
                Console.WriteLine("CreatedAt: " + product.GetCreatedAt());
                Console.WriteLine("NumberOfOrders: " + product.GetNumberOfOrders());
                Console.WriteLine("inStock: " + product.GetInStock());
                Console.WriteLine("----------------------------------------------");
            }
        }
        public static void DYWToContinue(){
            //continue?
            Console.Write("Do you want to continue ( No / Yes ): ");
            exitStatus = Console.ReadLine();
            if (exitStatus.ToLower() == "no")
            {
                exit = true;
            }

        }

        public static void AddProductToCart(int IdProduct){
            for (int i = products.Count-1; i >= 0; i--)
            {
                if (products[i].GetId() == IdProduct)
                {
                    ProductsToPurchase.Add(products[i]);
                }
            }
        }

        public static float TotalToPay(){
            float total = 0;
            foreach (var product in ProductsToPurchase)
            {
                total = total + product.GetPrice();
            }
            return total;
        }

        public static void CreateProduct(){
            int Id = products.Count + 1;
            Console.Write("enter product name :");
            string Name = Console.ReadLine();;
            Console.Write("enter product Description :");
            string Description = Console.ReadLine();
            Console.Write("enter product price :");
            float Price = float.Parse(Console.ReadLine());
            PrintCategoryList();
            Console.Write("choose a category from the list above (enter Id) : ");
            int categoryId = Convert.ToInt32(Console.ReadLine());
            Category choosenCategory = categories[0];
            foreach (var category in categories)
            {
                if (category.GetId()==categoryId)
                {
                    choosenCategory = category;
                }
            }
            Console.Write("enter product reference :");
            string Reference = Console.ReadLine();
            DateTime CreatedAt = DateTime.Now;
            int NumberOfOrders = 0;
            Console.Write("is the product available in stock ? ( yes / no )");
            string optionIS = Console.ReadLine();
            Boolean InStock = true;
            if (optionIS.ToLower() == "no")
            {
                InStock = false;
            }
            Product product = new Product( Id, Name,  Description, Price, choosenCategory,  Reference,  CreatedAt,  NumberOfOrders,  InStock);
            products.Add(product);

        }

        public static void CreateCategory(){
            int Id = categories.Count + 1;
            Console.Write("enter category name :");
            string Name = Console.ReadLine();;
            Console.Write("enter category Description :");
            string Description = Console.ReadLine();

            Category category = new Category( Id, Name,  Description );
            categories.Add(category);

        }

        public static void UpdateProduct(int IdProduct){
            for (int i = products.Count-1; i >= 0; i--)
            {
                if (products[i].GetId() == IdProduct)
                {
                    Console.Write("enter the new product name :");
                    string Name = Console.ReadLine();
                    Console.Write("enter the new product Description :");
                    string Description = Console.ReadLine();
                    Console.Write("enter the new product price :");
                    float Price = float.Parse(Console.ReadLine());
                    Console.Write("enter the new category name :");
                    string category = Console.ReadLine();
                    Category Category = new Category(products.Count + 1,category,Description);
                    Console.Write("enter the new product reference :");
                    string Reference = Console.ReadLine();
                    Console.Write("is the product available in stock ? ( yes / no )");
                    string optionIS = Console.ReadLine();
                    Boolean InStock = true;
                    if (optionIS.ToLower() == "no")
                    {
                        InStock = false;
                    }
                    products[i].SetName(Name);
                    products[i].SetDescription(Description);
                    products[i].SetPrice(Price);
                    products[i].SetCategory(Category);
                    products[i].SetReference(Reference);
                    products[i].SetInStock(InStock);
                }
            }
        }

        public static void UpdateCategory(int IdCategory){
            for (int i = categories.Count-1; i >= 0; i--)
            {
                if (categories[i].GetId() == IdCategory)
                {
                    Console.Write("enter the new category name :");
                    string Name = Console.ReadLine();
                    Console.Write("enter the new category Description :");
                    string Description = Console.ReadLine();
                    categories[i].SetName(Name);
                    categories[i].SetDescription(Description);
                }
            }
        }

        public static void DeleteProduct(int IdProduct){
            for (int i = products.Count-1; i >= 0; i--)
            {
                if (products[i].GetId() == IdProduct)
                {
                    products.RemoveAt(i);
                }
            }
        }

        public static void DeleteCategory(int IdCategory){
            for (int i = categories.Count-1; i >= 0; i--)
            {
                if (categories[i].GetId() == IdCategory)
                {
                    categories.RemoveAt(i);
                }
            }
        }

        public static void AddPaymentMethod(){
            Console.Write("enter the card title :");
            string Title = Console.ReadLine();
            Console.Write("choose the card type ( visa / mastercard / americanExpress / discover ) :");
            string Type = Console.ReadLine();
            int Index = 0;
            if (Type.ToLower() == "visa")
            {
                Index = 0;
            }else if(Type.ToLower() == "mastercard"){
                Index = 1;
            }else if(Type.ToLower() == "americanexpress"){
                Index = 2;
            }else if(Type.ToLower() == "discover"){
                Index = 3;
            }else{
                Console.WriteLine("Invalid card type!");
                DYWToContinue();
            }
            Console.Write("enter the card holder name :");
            string CardHolderName = Console.ReadLine();
            Console.Write("enter the card number :");
            string CardNumber = Console.ReadLine();
            Console.Write("enter the expiration date ( 00/00/0000 ) :");
            string StringDate = Console.ReadLine();
            DateTime ExpirationDate = Convert.ToDateTime(StringDate);
            Console.Write("enter the card CVC :");
            string CVC = Console.ReadLine();
            Console.Write("enter the card sold :");
            float Sold = float.Parse(Console.ReadLine());
            DateTime DateAdded = DateTime.Now;          
            PaymentMethod = new PaymentMethod( Title, Index, CardHolderName, CardNumber, ExpirationDate, CVC, Sold, DateAdded);
        }

        public static void ReadPaymentMethod(){
            if(PaymentMethod==null){
                Console.WriteLine("no payment method has been found!");
            }else{
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Card Type : "+PaymentMethod.GetChosenType());
                Console.WriteLine("Card Holder Name : "+PaymentMethod.GetCardHolderName());
                Console.WriteLine("Expiration Date : "+PaymentMethod.GetExpirationDate());
                Console.WriteLine("CVC : "+PaymentMethod.GetCVC());
                Console.WriteLine("Sold : "+PaymentMethod.GetSold());
                Console.WriteLine("----------------------------------------------");
            }
        }
        public static void UpdatePaymentMethod(){
            if(PaymentMethod==null){
                Console.WriteLine("no payment method has been added!");
            }else{
                Console.Write("enter the new card title :");
                string Title = Console.ReadLine();
                Console.Write("choose the new card type ( visa / mastercard / americanExpress / discover ) :");
                string Type = Console.ReadLine();
                Console.Write("enter the new card holder name :");
                string CardHolderName = Console.ReadLine();
                Console.Write("enter the new card number :");
                string CardNumber = Console.ReadLine();
                Console.Write("enter the new expiration date ( 00/00/0000 ) :");
                string StringDate = Console.ReadLine();
                DateTime ExpirationDate = Convert.ToDateTime(StringDate);
                Console.Write("enter the new card CVC :");
                string CVC = Console.ReadLine();
                Console.Write("enter the new card sold :");
                float Sold = float.Parse(Console.ReadLine());
                DateTime DateAdded = DateTime.Now;
                PaymentMethod.SetTitle(Title);
                PaymentMethod.SetChosenType(Type); 
                PaymentMethod.SetCardHolderName(CardHolderName); 
                PaymentMethod.SetCardNumber(CardNumber); 
                PaymentMethod.SetExpirationDate(ExpirationDate); 
                PaymentMethod.SetCVC(CVC); 
                PaymentMethod.SetSold(Sold);         
            }
        }

        public static void DeletePaymentMethod(){
            if (PaymentMethod == null)
            {
                Console.WriteLine("no payment method has been added!");
            }else{
                PaymentMethod = null;
                Console.WriteLine("payment method deleted successfully!");
            }

        }

        public static void PurchaseCartsProducts(){
            if (Cart.GetProducts().Count == 0)
            {
                Console.WriteLine("You should have at least one product in your cart!");
            }else if(PaymentMethod == null){
                Console.WriteLine("no payment method has been added!");
            }else{

                if (PaymentMethod.GetSold() < TotalToPay())
                {
                    Console.WriteLine("not enough funds!");
                }else{
                    // increment NumberOfOrders
                    foreach (var product in Cart.GetProducts())
                    {
                        product.SetNumberOfOrders(product.GetNumberOfOrders()+1);
                    }
                    DateTime DateAdded = DateTime.Now;
                    Order Order;
                    Order = new Order(currentUser.GetFullName(),Cart.GetProducts(),TotalToPay(),DateAdded);
                    orders.Add(Order);
                    PaymentMethod.SetSold( PaymentMethod.GetSold() - TotalToPay() );
                    Console.WriteLine("The payment has been done!");
                    Console.WriteLine("The total paid is : "+TotalToPay()+" USD");
                    Console.WriteLine("Your purchased products!");
                    PrintProductToPurchaseList();         
                }
                
            }
        }

    }

}
