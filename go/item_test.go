package main

import (
	"tddshop/ts"
	"testing"
)

// Item
func TestItemNameAndPrice(t *testing.T) {
	item := ts.Item{
		Name:  "Black Pants",
		Price: 60,
	}

	if item.Name != "Black Pants" || item.Price != 60 {
		t.Error()
	}
}

// ItemBatch
func TestItemBatch(t *testing.T) {
	item := ts.Item{Name: "Red Shoes", Price: 50}
	itemBatch := ts.ItemBatch{Item: item, Quantity: 100}
	if item != itemBatch.Item || 100 != itemBatch.Quantity {
		t.Error()
	}
}
