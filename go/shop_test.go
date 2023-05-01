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

func TestStockAvailable_ZeroWithoutItems(t *testing.T) {
	shop := ts.Shop{}
	if shop.StockAvailable("White Shoes") != 0 {
		t.Error()
	}
}

func TestStockAvailable_WithItems(t *testing.T) {
	shop := ts.Shop{}
	itemBatch := ts.ItemBatch{Item: ts.Item{Name: "White Shoes", Price: 100}, Quantity: 11}
	shop.Add(itemBatch)

	if shop.StockAvailable("White Shoes") != 11 {
		t.Error()
	}
}

func TestRevenue_AtBegin_Zero(t *testing.T) {
	shop := ts.Shop{}
	if shop.Revenue != 0 {
		t.Error()
	}
}

func TestBuy_ReducesFundsAndStock(t *testing.T) {
	shop := ts.Shop{}
	item := ts.Item{Name: "Black Belt", Price: 10}
	itemBatch := ts.ItemBatch{Item: item, Quantity: 7}

	shop.Add(itemBatch)

	if shop.StockAvailable("Black Belt") != 7 || shop.Revenue != 0 {
		t.Error()
	}

	funds := 100
	shop.Buy("Black Belt", &funds)

	if shop.StockAvailable("Black Belt") != 6 || shop.Revenue != 10 || funds != 90 {
		t.Error()
	}
}
