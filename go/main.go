package main

import (
	"fmt"
	"tddshop/ts"
)

func main() {
	customer := ts.Customer{Funds: 100}
	fmt.Println(customer.Funds)
}
