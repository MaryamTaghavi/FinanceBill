# Logging Level

1. Trace

خیلی خیلی ریز و پرجزئیات.

معمولاً شامل اطلاعاتی مثل مقدار متغیرها، ورودی و خروجی توابع و مسیر دقیق اجرای کد.

چون خیلی زیاد و حساس هستن، معمولاً توی Production غیرفعال می‌شن.

📌 مثال:

logger.LogTrace("Starting method GetUser with parameter id={Id}", id);

2. Debug

برای اشکال‌زدایی (Debugging) استفاده می‌شه.

اطلاعات کلی‌تر نسبت به Trace می‌ده، اما هنوز بیشتر به درد توسعه‌دهنده می‌خوره تا کاربر یا مدیر سیستم.

معمولاً فقط تو محیط Development روشن می‌شه.

📌 مثال:

logger.LogDebug("Query executed in {ElapsedMilliseconds} ms", stopwatch.ElapsedMilliseconds);

3. Information

برای رخدادهای عادی و جریان کلی برنامه استفاده می‌شه.

چیزایی که ارزش تاریخی دارن، مثلاً: یک کاربر لاگین کرده، پرداخت موفق بوده، سرویس استارت شده.

این لاگ‌ها معمولاً همیشه در Production فعالن.

📌 مثال:

logger.LogInformation("User {UserId} logged in successfully", userId);

4. Warning

وقتی اتفاقی غیرعادی میفته ولی هنوز برنامه متوقف نشده.

یه هشدار برای اینکه «یه چیزی درست نیست، ولی هنوز جدی نشده».

📌 مثال:

logger.LogWarning("Payment took unusually long: {Duration} ms", duration);

5. Error

وقتی یه خطای واقعی رخ داده که باعث شده روند فعلی متوقف بشه.

مثلاً کاربر نتونسته خرید کنه چون بانک جواب نداده.

برنامه ادامه پیدا می‌کنه، ولی اون درخواست یا اکشن شکست خورده.

📌 مثال:

logger.LogError(ex, "Error while saving order {OrderId}", order.Id);

6. Critical

جدی‌ترین سطح لاگ.

برای مواردی که کل برنامه یا سیستم از کار افتاده یا یه خطای فاجعه‌آمیز رخ داده.

نیازمند توجه فوری.

📌 مثال:

logger.LogCritical("Database unavailable. Application shutting down.");
