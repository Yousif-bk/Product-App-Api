namespace ProductsApi.Contracts
{
    public static class ApiRoute
    {
        public static class Account
        {
            public const string Login = "api/account/login";
            public const string Create = "api/account/create";
        }

        public static class Product
        {
            public const string Search = "api/product/search";
            public const string Create = "api/product/create";
            public const string Delete = "api/product/delete/{id}";
            public const string Update = "api/product/update/{id}";
            public const string GetProduct = "api/product/detail/{id}";
        }

    }
}