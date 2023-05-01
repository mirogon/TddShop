package ts

type Shop struct {
	Items []ItemBatch
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
