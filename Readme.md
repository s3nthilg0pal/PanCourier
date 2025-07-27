# Quote service for an imaginary company called PanCourier

### Input
Input for the Quote service is `Consignment` that takes list of `Parcels`

### Output
Output of the Quote Service is `Quote` with collection of `lineItems` and total cost.
`LineItem` holds the LineItemType and its cost.

`LineItemType` is an enum that contains type
1. Small
2. Medium
3. Large
4. ExtraLarge
5. SpeedyShipping

### Parcel
Assuming all the parcel dimensions are fall into a valid size.

### Product Option
Added a internal type that holds the information about parcel basecost, weight limit, weight surcharge for easy lookup.
In real world, assuming this data will be stored in a database.

### Test
Some of the test are written with the help of AI

#### Promp used for generating tests
> Generate unit tests for the following C# function using nUnit 3
> 
> `CODE`
> 
>  Ensure the tests cover:
>  - Positive scenarios with various valid inputs.
>  - Negative scenarios including invalid inputs, edge cases (e.g., null, empty, boundary values).
>  - Adhere to the Arrange-Act-Assert (AAA) pattern.
>  - Handle error conditions and exceptions where applicable.

### Version control
For simplicity, all the commits are pushed directly to main insead of craeting a PR.