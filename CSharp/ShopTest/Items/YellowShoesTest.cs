﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopTest.Items {
    using Shop.Items;
    public class YellowShoesTest {
        [Fact]
        public void NameAndValue_Correct() {
            ItemOld yellowShoes = new YellowShoes();
            Assert.Equal(55, yellowShoes.Value);
        }
    }
}
