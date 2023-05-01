package main

import (
	"tddshop/ts"
	"testing"
)

func TestShop_AddItem(t *testing.T) {
	s := ts.Shop{}
	if len(s.Items) != 0 {
		t.Error()
	}

	item := ts.Item{
		Name:  "Red Shoes",
		Price: 50,
	}
	itemBatch := ts.ItemBatch{
		Item:     item,
		Quantity: 100,
	}

	s.Add(itemBatch)

	if len(s.Items) != 1 {
		t.Error()
	}

	if s.Items[0].Quantity != 100 {
		t.Error()
	}
}

func TestAddTwoTimes_AddsStock(t *testing.T) {
	shop := ts.Shop{}
	item := ts.Item{Name: "Black Shirt", Price: 15}
	itemBatch := ts.ItemBatch{Item: item, Quantity: 50}

	shop.Add(itemBatch)

	if len(shop.Items) != 1 || shop.Items[0].Quantity != 50 {
		t.Error()
	}

	shop.Add(itemBatch)

	if len(shop.Items) != 1 || shop.Items[0].Quantity != 100 {
		t.Error(shop.Items)
	}
}
