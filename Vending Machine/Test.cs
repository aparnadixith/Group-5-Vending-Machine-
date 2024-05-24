using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class VedndingMachineTest
    {
        [Fact]
        public void InsertMoney_ValidDenomination_AddsToMoneyPool()
        {
        var vendingMachine = new VendingMachineService();
        vendingMachine.InsertMoney(10);
        var change = vendingMachine.EndTransaction();
            Assert.Contains(10, change.Keys);
            Assert.Equal(1, change[10]);
        }
        [Fact]
        public void Purchse_ProductAvaliableAndSufficientFunds_ReducesMoneyPool()
        {
            var vendingMachine = new VendingMachineService();
            vendingMachine.InsertMoney(50);
            vendingMachine.Purchase(1);
            var change = vendingMachine.EndTransaction();
            Assert.Equal(30, change.Keys.Sum(k => k * change[k]));
        }
        [Fact]
        public void Purchase_ProductNotAvailable_ThrowsException()
        {
            var vendingMachine = new VendingMachineService();
            Assert.Throws<Exception>(() => vendingMachine.Purchase(999));
        }

        [Fact]
        public void InsertMoney_InvalidDenomination_ThrowsException()
        {
            var vendingMachine = new VendingMachineService();
            Assert.Throws<Exception>(() => vendingMachine.InsertMoney(3));
        }

        [Fact]
        public void EndTransaction_ReturnsChangeCorrectly()
        {
            var vendingMachine = new VendingMachineService();
            vendingMachine.InsertMoney(100);
            var change = vendingMachine.EndTransaction();
            Assert.Contains(100, change.Keys);
            Assert.Equal(1, change[100]);
        }
    }

}

