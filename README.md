MovieController -> MovieService -> MovieRepository -> Database
    MovieRepository : Model - ten podstawowy model musi byc polaczony z baza danych
        Task <Movie> GetAsync(id)
        Task <IEnumerable<Movies>> GetMoviesAsync()
        Task <Photo> GetPhoto()
        Task AddAsync
        Task UpdateAsync
        Task DeleteAsync

    MovieService : DTO and mapper
        Task<MovieDTO> GetAsync(Guid id)
        Task<IEnumerable<MovieDTO>> GetMoviesAsync()
        Task CreateAsync(Guid id, string title, string description, string photoUrl        // tworzenie wydarzenia
            DateTime time);
        Task AddTicketsAsync(Guid movieId, int amount, decimal price);      // dodawanie biletow
        Task UpdateAsync(Guid id, string title, string description);        // update wydarzenia
        Task DeleteAsync(Guid id);                                          // usuwanie



AccountController -> UserService -> UserRepository -> Database
    UserRepository : User
        Task <User> GetAsync(Guid id)
        Task Addasync (User user)
        Task UpdateAsync (User user)
        Task DeleteAsync (User user)

    UserService : UserDTO
        Task <UserDTO> GetAccountAsync(Guid userId)
        Task RegisterAsync(Guid userId, string email,
            string name, string password, string role = "user")
        Task<TokenDto> LoginAsync(string email, string password);