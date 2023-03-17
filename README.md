Описание API игры в крестики-нолики:

1) GET /game/start
Запускает новую игру. Возвращает идентификатор игры и определяет, какой игрок начнет игру первым.

Параметры:
Нет.

Ответ:
{
  "gameId": "123456",
  "player": "X"
}

2) GET /game/{gameId}
Получить текущее состояние игры.

Параметры:
gameId - идентификатор игры.

Ответ:
{
  "board": [
    ["O", "", "X"],
    ["", "X", ""],
    ["O", "", ""]
  ],
  "player": "O",
  "status": "In Progress"
}

3) POST /game/{gameId}
Ход игрока.

Параметры:
gameId - идентификатор игры.

Тело запроса:
{
  "player": "X",
  "x": 1,
  "y": 2
}
player - символ, которым играет игрок. Значение должно соответствовать текущему игроку, который должен сделать ход.
x, y - координаты, где будет поставлен символ.

Ответ:
{
  "board": [
    ["O", "", "X"],
    ["", "X", ""],
    ["O", "", ""]
  ],
  "player": "X",
  "status": "In Progress"
}
Если ход невозможен (например, ячейка уже занята или игра закончена), API вернет соответствующую ошибку.

4) DELETE /game/{gameId}
Отменить текущую игру.

Параметры:
gameId - идентификатор игры.

Ответ:
Нет.