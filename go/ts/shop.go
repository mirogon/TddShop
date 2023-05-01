package ts

type Shop struct {
	Items   []ItemBatch
	Revenue int
}

func (s *Shop) Add(itemBatch ItemBatch) {
	for i := 0; i < len(s.Items); i++ {
		if s.Items[i].Item.Name == itemBatch.Item.Name {
			s.Items[i].Quantity += itemBatch.Quantity
			return
		}
	}
	s.Items = append(s.Items, itemBatch)
}

func (s *Shop) Buy(itemName string, funds *int) {
	for i := 0; i < len(s.Items); i++ {
		if s.Items[i].Item.Name == itemName {
			if *funds >= s.Items[i].Item.Price {
				s.Items[i].Quantity -= 1
				*funds -= s.Items[i].Item.Price
				s.Revenue += s.Items[i].Item.Price
			}
			return
		}
	}

}

func (s Shop) StockAvailable(itemName string) int {
	for _, v := range s.Items {
		if v.Item.Name == itemName {
			return v.Quantity
		}
	}
	return 0
}
