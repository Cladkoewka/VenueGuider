# VenueGuider - Тестовое задание для С# разработчика

Сделал Терехов Семён

## Описание проекта

Данный проект представляет собой тестовое задание для разработки API с использованием ASP.NET Core 8 и Entity Framework Core. 
Приложение реализует систему управления заведениям с поддержкой CRUD операций, а также позволяет управлять категориями и тегами для заведений.

## Использованные технологии

- **ASP.NET Core 8**: Фреймворк для создания веб-приложений и API.
- **Entity Framework Core**: ORM для работы с базой данных.
- **Swagger**: Для автогенерации документации API и тестирования конечных точек.
- **Postman**: Для тестирования API (опционально).

## Эндпоинты

### Категории

- `GET /api/categories` - Получить все категории.
- `GET /api/categories/{id}` - Получить категорию по ID.
- `POST /api/categories` - Добавить новую категорию.
- `PUT /api/categories/{id}` - Обновить существующую категорию.
- `DELETE /api/categories/{id}` - Удалить категорию по ID.

### Заведения

- `GET /api/venues` - Получить все заведения.
- `GET /api/venues/{id}` - Получить заведение по ID.
- `GET /api/venues/category/{categoryId}` - Получить заведения по ID категории.
- `POST /api/venues` - Добавить новое заведение.
- `PUT /api/venues/{id}` - Обновить существующее заведение.
- `DELETE /api/venues/{id}` - Удалить заведение по ID.
- `POST /api/venues/{venueId}/tags/{tagId}` - Добавить тег к заведению.
- `DELETE /api/venues/{venueId}/tags/{tagId}` - Удалить тег из заведения.

### Теги

- `GET /api/tags` - Получить все теги.
- `GET /api/tags/{id}` - Получить тег по ID.
- `POST /api/tags` - Добавить новый тег.
- `PUT /api/tags/{id}` - Обновить существующий тег.
- `DELETE /api/tags/{id}` - Удалить тег по ID.


