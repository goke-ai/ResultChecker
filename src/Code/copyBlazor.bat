rem xcopy Entities\*.cs "..\Ark.ResultCheckers.Entities\Auto" /s /e /exclude:copyit-xlist.txt
rem xcopy Entities\*.cs "..\Ark.ResultCheckers.Entities\Auto" /s /e /exclude:copyit-xlist.txt
rem xcopy Dtos\Caches\*.cs "..\Ark.ResultCheckers.Dtos\Caches\Auto" /s /e /exclude:copyit-xlist.txt
rem xcopy Dtos\Dtos\*.cs "..\Ark.ResultCheckers.Dtos\Dtos\Auto" /s /e /exclude:copyit-xlist.txt
rem xcopy Data\*.cs "..\..\..\ResultCheckers\BlazorApp\Data\Auto" /s /e /exclude:copyit-xlist.txt
rem xcopy DataServices\*.cs "..\Ark.ResultCheckers.Data\Services\Auto" /s /e /exclude:copyit-xlist.txt
xcopy Blazor\*.razor "..\..\ResultCheckers\Client\Components" /s /e /exclude:copyit-xlist.txt
xcopy BlazorEditDialog\*.razor "..\..\ResultCheckers\Client\Components" /s /e /exclude:copyit-xlist.txt
xcopy BlazorEdit\*.razor "..\..\ResultCheckers\Client\Components" /s /e /exclude:copyit-xlist.txt
xcopy BlazorList\*.razor "..\..\ResultCheckers\Client\Components" /s /e /exclude:copyit-xlist.txt
xcopy Blazor\*.cs "..\..\ResultCheckers\Client\Components" /s /e /exclude:copyit-xlist.txt
rem xcopy Models\*.cs "..\..\..\ResultCheckers\BlazorApp\Models\" /s /e /exclude:copyit-xlist.txt
rem xcopy Apis\*.cs "..\..\NgApiApp\" /s /e /exclude:copyit-xlist.txt
rem xcopy ts\*.ts "..\..\NgApiApp\ClientApp\src\app\" /s /e /exclude:copyit-xlist.txt
rem xcopy "ts\shared" "..\..\dnc\UNg2\ClientApp\app\components\shared\" /s /e /exclude:copyit-xlist.txt
