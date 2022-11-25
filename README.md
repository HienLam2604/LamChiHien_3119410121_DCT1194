
# Xây dựng phần mềm theo mô hình phân lớp - DCT1194  

## Thông tin sinh viên:
|              | Thông tin                                                                |
| ----------------- | ------------------------------------------------------------------ |
| Tên sinh viên |   *Lâm Chí Hiền*  |
| Mã số sinh viên |  *3119410121* |


## Bài tập cá nhân: Hoàn thành payment record
- Hoàn thành payservice
- Tạo ViewModel (Index, create, detail)
- Hoàn thành Controlller PayController
- Hoàn thành View (Index, create, detail)


## API Reference

#### Get all Payment Record

```http
  [GET] /PaymentRecords
```

#### Create Payment Record

```http
  [POST, GET] /PaymentRecords/Create
```

#### View Payslip
```http
  [GET] /PaymentRecords/Detail/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of PaymentRecords to fetch |


# Result 
#### Side bar
![Alt text](/assets/side-bar.PNG "Side bar")

#### Create Pay Record 
![Alt text](/assets/create-1.PNG "Create Pay Record ")

#### Validation for Pay Record
![Alt text](/assets/create-2.PNG "Validation for Pay Record")

#### Valid Pay Record
![Alt text](/assets/create-3.PNG "Valid Pay Record")

#### View all Payment Record
![Alt text](/assets/create-4.PNG "View all Payment Record")

#### View detail payslip
![Alt text](/assets/create-5.PNG "View detail payslip")

## Authors

- [@LamChiHien - 3119410121](https://github.com/HienLam2604)

