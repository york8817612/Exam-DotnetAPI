# Exam Api
## 說明
這是一個為考試系統寫的API

## 功能
1. []考試項目CRUD
2. []考試題目CRUD
3. []權限
4. []考試
5. []考試模式
6. []考試題庫陣列
7. []題庫匯入

## 結構

### 考試

| API | 描述 | 要求本文 | 回應本文|
| - | - | -| - |
| GET api/exam/{id} | 依識別碼取得考試題庫 | 無 | 考試題庫陣列 |
| POST api/exam/{id} | 依識別碼取得考試題目 | 無 | 考試題目陣列 |
| POST api/exam/check/ | 檢查所有答題狀況 | 答案陣列 | 無 |
| POST api/exam/check/{id} | 檢查單一答題狀況 | 答案 | 無 |

### 考試列表

| API | 描述 | 要求本文 | 回應本文|
| - | - | -| - |
| GET api/examitems | 取得所有考試項目 | 無 | 考試項目陣列 |
| GET api/examitems/{id} | 依識別碼取得項目 | 無 | 考試項目 |
| POST api/examitems | 建立考試項目 | 考試項目 | 無 |
| POST api/examitems/export | 匯入考試項目 | csv | 無 |
| PUT api/examitems/{id} | 修改考試項目 | 考試項目 | 無 |
| DELETE api/examitems/{id} | 刪除考試項目 | 無 | 無 |

### 考試題目

| API | 描述 | 要求本文 | 回應本文|
| - | - | -| - |
| GET api/questionitems/{id} | 依識別碼取得考試題目 | 無 | 考試題目陣列 |
| POST api/questionitems | 建立考試題目 | 考試題目 | 無 |
| PUT api/questionitems/{id} | 修改考試題目 | 考試題目 | 無 |
| DELETE api/questionitems/{id} | 刪除考試題目 | 無 | 無 |

### 資料庫

* examitems

> | 欄位 | 類型 | 描述 |
> | - | - | -|
> | id | guid | 識別碼 |
> | name | varchar(50) | 考試項目名稱 |
> | enable | tinyint(1) | 考試項目狀態 |
> 

* questionitems

> | 欄位 | 類型 | 描述 |
> | - | - | -|
> | id | guid | 識別碼 |
> | examitemid | guid | 考試項目識別碼 |
> | questiontype | tinyint(1) | 考試類型 |
> | text | text | 考試題目 |
> 

* anwseritems

> | 欄位 | 類型 | 描述 |
> | - | - | -|
> | id | guid | 識別碼 |
> | questionitemid | guid | 考試題目識別碼 |
> | text | text | 考試答案 |
> | correct | tinyint(1) | 是否為答案 |
> 


