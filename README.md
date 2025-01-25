Simple app for university classes, helps with a movies finds and for admin, with handling the movies database.
https://docs.google.com/document/d/1PAdyp0oNIU1iiAodY1D5w2DciN6GZztWGW0PongVJlY/edit?tab=t.0 - some first sight functionalities:

functionalities:                                                                      Funkcjonalości:
- Adding new movie [POST] - only available for Admin role account.                    Dodawanie nowego filmu, dostepne dla administratora.
- Deleting movie - only available for Admin role account.                             Usuwanie wybranego filmu, dostępne dla administratora.
- Editing movie [POST] - only available for Admin role account.                       Edytowanie wybranego filmu, dostępne dla administratora.
- View of all the movies - is shown for everyone                                      Wyświetlanie listy wszystkich filmów, ogólnodostępne.
- Search bar searchs for title, even spelling only some letters of phrase.            Wyszukiwanie na podstawie tytułu, również tylko pierwszych liter.
- Registration panel - is used to register an account                                 Panel rejestracji, służy do załozenia konta.
- Login panel - is used to login at registered account                                Panel logowania, służy do zalogowania się na istniejące konto.
- Logout - is used to end up session by logging out of account                        Wylogowywania się, kończy sesje zalogowanego konta.
how to start using:                                                                   Jak użyć aplikacji?
Instalation:                                                                          Instalacja:
  - git clone https://github.com/makovvka/MoviesRental                                - git clone https://github.com/makovvka/MoviesRental
  - cd WebAppliaction1                                                                - cd WebAppliaction1 
Preparing database:                                                                   Przygotowanie bazy danych
  in appsetting.json configure connection with SQLServer, then migrate:               w appsetting.json skonfigurować połączenie z SQLServer i zrobić migrację
  dotnet ef Add-Migration {...}                                                       dotnet ef Add-Migration {...nazwa migracji...}
  dotnet ef Update-database                                                           dotnet ef Update-database
Starting Application:                                                                 Uruchomienie aplikacji
  dotnet run                                                                          dotnet run
