var ordersApp = angular.module('ordersApp', []), Order;


Order = (function () {
    function Order(_title, _count, _address) {
        this.title = _title;
        this.id = null;
        this.count = _count;
        this.address = _address;
    }

    Order.prototype.validate = function () {
        if (this.title && (this.count > 0) && this.address) {
            return true;
        }
    };

    return Order;
})();

ordersApp.controller('OrderListController', function($scope, $http) {
    $http.get('api/orders/getall').success(function(data, status, headers, config) {
        $scope.orders = data;
    });

    $scope.newOrder = new Order();

    $scope.addOrder = function () {
        if ($scope.newOrder.validate()) {
            $http.post('api/orders/add', $scope.newOrder).success(function(data) {
                $scope.newOrder.id = data.id;
                $scope.orders.push($scope.newOrder);
                $scope.newOrder = new Order();
            });
        }
        else alert("Не все поля заполненны");
    }

    $scope.deleteOrder = function (id, index) {
        $http.post('api/orders/delete/'+ id).success(function(data) {
            $scope.orders.splice(index, 1);
        }).error(function(err) {
            console.log(err);
        });

    }
});


