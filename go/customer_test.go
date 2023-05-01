package main

import (
	"tddshop/ts"
	"testing"
)

func TestCustomerFunds(t *testing.T) {
	customer := ts.Customer{Funds: 100}
	if customer.Funds != 100 {
		t.Error()
	}
}
