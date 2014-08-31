var jqGameArea;

var LEVEL_WIDTH = 40;
var LEVEL_HEIGHT = 40;
var GAME_AREA_WIDTH;
var GAME_AREA_HEIGHT;
var TILE_PIXEL_WIDTH = 30;
var TILE_PIXEL_HEIGHT = 30;

var currentGame;
var nextUnitID = 0;
$(document).ready(function () {
    initUINumbers();
    initGame();
});

var initUINumbers = function () {
    jqGameArea = $('#game-area');
    GAME_AREA_WIDTH = jqGameArea.width();
    GAME_AREA_HEIGHT = jqGameArea.height();
};

var initGame = function () {
    var host = createPlayer("Thomas");
    var opponent = createPlayer("Andreas");
    var commander = createUnitType("Commander", 20, 2, 100, 5, 1, 4);
    var unit1 = createUnit(host, commander, 10, 10);
    var unit2 = createUnit(opponent, commander, -10, -10);
    host.units = [unit1];
    opponent.units = [unit2];
    var newGame = {
        players: [host, opponent],
        host: host,
        units: [unit1, unit2]
    };
    currentGame = newGame;
    _game.start(currentGame);
    _game.setUpLevel(currentGame);
};

var _game = {
    start: function (game) {
        game.currentTurn = 0;
        game.currentPlayer = game.players[Math.floor((Math.random() * 2) + 1)];
    },
    setUpLevel: function (game) {
        jqGameArea.empty();
        for (var playerIndex in game.players) {
            var player = game.players[playerIndex];
            for (var unitIndex in player.units) {
                var unit = player.units[unitIndex];
                var jqUnit = $('<div class="unit">');
                jqUnit.css('left', (GAME_AREA_WIDTH / 2) + TILE_PIXEL_WIDTH * unit.positionX + 'px');
                jqUnit.css('top', (GAME_AREA_HEIGHT / 2) + TILE_PIXEL_HEIGHT * unit.positionY + 'px');
                jqUnit.attr('unit-id', unit.id);
                jqGameArea.append(jqUnit);
                jqUnit.click(function () {
                    selectUnit($(this));
                });
            }
        }
    }
};

var selectUnit = function (jqUnit) {
    var unitId = jqUnit.attr('unit-id');
    var selectedUnit;
    for (var unitIndex in currentGame.units) {
        var unit = currentGame.units[unitIndex];
        if (unit.id == unitId) {
            selectedUnit = unit;
        }
    }
    console.log(selectedUnit.positionX + ", " + selectedUnit.positionY);
};

var createPlayer = function (name){
    return {
        name: name
    };
};

var createUnitType = function (name, damage, attackSpeed, hitPoints, energy, attacks, energyPerAttack) {
    return {
        name: name,
        damage: damage,
        attackSpeed: attackSpeed,
        hitPoints: hitPoints,
        energy: energy,
        attacks: attacks,
        energyPerAttack: energyPerAttack
    };
};

var createUnit = function (player, unitType, positionX, positionY) {
    nextUnitID++;
    return {
        id: nextUnitID - 1,
        player: player,
        unitType: unitType,
        positionX: positionX,
        positionY: positionY
    };
};