$(document).ready(function () {

    $(document).on('click', 'img[name=add-coin]', function (e) {
        var $button = $(this);
        var coinTypeID = $button.attr('data-id');
        var model = {
            coinTypeID: coinTypeID
        }

        Layout.MVC.post("CoinJar", 'AddCoinToJar', model, {
            success: function (result) {
                $('span[name=coin-jar-volume]').text(result.actualVolume);
                $('span[name=coin-jar-amount]').text(result.actualAmmount);
            },
            error: function (error) {
                alert("Something went wrong with adding the coin to the jar.");
            }
        });
    });

    $(document).on('click', 'button[name=reset]', function (e) {

        Layout.MVC.post("CoinJar", 'ResetCount', null, {
            success: function (result) {
                $('span[name=coin-jar-volume]').text(result.actualVolume);
                $('span[name=coin-jar-amount]').text(result.actualAmmount);
                $('label[name=coin-jar-total-message]').text(result.message);
            },
            error: function (error) {
                alert("Something went wrong with the reset");
            }
        });
    });
});