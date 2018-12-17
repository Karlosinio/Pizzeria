Moduł produkty:

przy picisku "Dodaj do koszyka" wywułujecie metodę CartVM.AddProduct - zwróćcie uwagę, że jest tutaj DTO, bo zawiera również te dodatkowe składniki.


Moduł finalizacja i dostawy :

Zestaw produktów pobierać z CartVM.GetOrderProducts, dostajecie listę produktów (po integracji dorobię obsługę komponentów, po usteleniu pewnych rzeczy z modułem produktów), gdzie każdy produkt ma cenę, więc wystarczy odwołać się do odpowiedniego pola.

Jeśli chodzi o zniżkę, to nie jest to kluczowa funkcjonalność na ten moment.
Ale wystarczy, że stworzycie instancję BaserService<Discount>, przeszukacie kolekcję czy zawiara taki kod, i czy nie został użyty itp. a potem odejmiecie od ceny odpowiedni procent. (Tak, tak to nasza funkcjonalność, jednak nie wiem czy uda mi się wieczorem to dorobić jak skończycie)