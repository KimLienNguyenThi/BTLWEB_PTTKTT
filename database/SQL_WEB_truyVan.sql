
USE QuanLyThuVien;
SELECT * FROM donvitl
SELECT * FROM PHIEUMUON
SELECT * FROM CHITIETPM 
SELECT * FROM PHIEUTRA 
SELECT * FROM CHITIETPT 
SELECT * FROM SACH
SELECT * FROM KHOSACHTHANHLY
SELECT * FROM PhieuThanhLy
SELECT * FROM ChiTietPTL

SELECT
    PM.MaPM,
    PM.MaThe,
    DG.HoTenDG AS 'HoTenDocGia',
    DG.SDT AS 'SDTDocGia',
    PM.NgayMuon,
    PM.HanTra,
	ctpm.masach
FROM
    PHIEUMUON PM
    JOIN CHITIETPM CTPM ON PM.MaPM = CTPM.MaPM
    JOIN DOCGIA DG ON PM.MaThe = DG.MaDG
WHERE NOT EXISTS (
    SELECT 1
    FROM
        CHITIETPT CTPT
        JOIN PHIEUTRA PT ON CTPT.MaPT = PT.MaPT
        JOIN DOCGIA DG_TRA ON PT.MaThe = DG_TRA.MaDG
    WHERE
        PM.MaThe = PT.MaThe
        AND CTPM.MaSach = CTPT.MaSach
        AND PM.MaPM = PT.MaPM
        AND CTPM.SoLuongMuon = (
            SELECT
                SUM(SoLuongTra + SoLuongLoi)
            FROM
                CHITIETPT
                JOIN PHIEUTRA ON CHITIETPT.MaPT = PHIEUTRA.MaPT
                JOIN DOCGIA ON PHIEUTRA.MaThe = DOCGIA.MaDG
            WHERE
                PM.MaThe = PHIEUTRA.MaThe
                AND CTPM.MaSach = CHITIETPT.MaSach
            GROUP BY
                PHIEUTRA.MaThe, -- Thêm cột này vào phần GROUP BY
                CHITIETPT.MaSach
        )
    )
GROUP BY
    PM.MaPM,
    PM.MaThe,
    DG.HoTenDG,
    DG.SDT,
    PM.NgayMuon,
    PM.HanTra,
	ctpm.masach;

	--********************************
	SELECT ChiTietPM.mapm ,ChiTietPM.MaSach,Soluongmuon ,sum(soluongtra+soluongloi) as setTinhTrang
	FROM ChiTietPM JOIN PHIEUTRA ON ChiTietPM.MaPM = PHIEUTRA.MaPm JOIN ChiTietPT ON PHIEUTRA.MAPT = ChiTietPT.MaPT
	WHERE ChiTietPM.MaSach = ChiTietPT.MaSach  and ChiTietPM.mapm = 1
	group by ChiTietPM.mapm ,ChiTietPM.MaSach,Soluongmuon
	having soluongmuon = sum(soluongtra+soluongloi) 


	--********************************

	--*******
	SELECT * FROM PhieuMuon WHERE MaPM = 4;
	SELECT * FROM ChiTietPM WHERE MaPM = 1;

	SELECT * FROM PhieuTra WHERE MaPt = 6;
	SELECT * FROM ChiTietPT WHERE MAPt IN (3,4)
	--******
		
SELECT * FROM PHIEUMUON
SELECT * FROM CHITIETPM 
SELECT * FROM PHIEUTRA 
SELECT * FROM CHITIETPT 
		insert into PhieuMuon ( MaThe, NgayMuon, HanTra,  MaNV) values (6, '2023-11-18', '2023-12-16',2);

-- Them chi tiet phieu muon
insert into ChiTietPM ( MaPM, MaSach, Soluongmuon) values ( 10, 10, 2);
insert into ChiTietPM ( MaPM, MaSach, Soluongmuon) values ( 13, 4, 1);

 insert into phieutra(ngaytra,manv,mathe,mapm) values ('2023-11-21',2,3,7)
  insert into phieutra(ngaytra,manv,mathe,mapm) values ('2023-11-22',2,1,1)

 insert into ChiTietPT(MaPT, MaSach, Soluongtra, Soluongloi) values(9,17,0,1)
  insert into ChiTietPT(MaPT, MaSach, Soluongtra, Soluongloi) values(9,20,1,0)
  --insert into ChiTietPT(MaPT, MaSach, Soluongtra, Soluongloi) values(6,4,1,0)


--so loai sách mượn
SELECT PM.mapm, count(pm.mapm) as loaisach
FROM PhieuMuon PM join chitietpm ctpm on PM.mapm  = ctpm.mapm 
WHERE PM.Tinhtrang = N'CHƯA TRẢ'
GROUP BY Pm.mapm
intersect
select mapm, count(mapm) as soluongls from 
--lấy sách trả roi
(SELECT PM.mapm , ctpm.masach, Soluongmuon
FROM PhieuMuon PM join chitietpm ctpm on PM.mapm  = ctpm.mapm 
WHERE PM.Tinhtrang = N'CHƯA TRẢ'
intersect
SELECT Pt.mapm,  ctpt.masach, SUM(ISNULL(ctpt.Soluongtra, 0) + ISNULL(ctpt.Soluongloi, 0)) AS soluongtra
FROM phieutra Pt
JOIN chitietpt ctpt ON Pt.mapt = ctpt.mapt
LEFT JOIN chitietpm ctpm ON Pt.mapm = ctpm.mapm AND ctpt.masach = ctpm.masach
GROUP BY Pt.mapm, ctpt.masach) as a
GROUP BY a.mapm;

--***********************
 ALTER TRIGGER UpdateTinhTrangPhieuMuon
ON chitietpt
for INSERT
AS
BEGIN
    UPDATE PM
    SET Tinhtrang = N'ĐÃ TRẢ'
    FROM PhieuMuon PM
    JOIN (
        SELECT PM.mapm, count(pm.mapm) as loaisach
        FROM PhieuMuon PM 
        JOIN chitietpm ctpm ON PM.mapm  = ctpm.mapm 
        WHERE PM.Tinhtrang = N'CHƯA TRẢ'
        GROUP BY Pm.mapm
        INTERSECT
        SELECT mapm, count(mapm) as soluongls 
        FROM (
            SELECT PM.mapm , ctpm.masach, Soluongmuon
            FROM PhieuMuon PM 
            JOIN chitietpm ctpm ON PM.mapm  = ctpm.mapm 
            WHERE PM.Tinhtrang = N'CHƯA TRẢ'
            INTERSECT
            SELECT Pt.mapm,  ctpt.masach, SUM(ISNULL(ctpt.Soluongtra, 0) + ISNULL(ctpt.Soluongloi, 0)) AS soluongtra
            FROM phieutra Pt
            JOIN chitietpt ctpt ON Pt.mapt = ctpt.mapt
            LEFT JOIN chitietpm ctpm ON Pt.mapm = ctpm.mapm AND ctpt.masach = ctpm.masach
            GROUP BY Pt.mapm, ctpt.masach
        ) AS a
        GROUP BY a.mapm
    ) AS CountResult ON PM.mapm = CountResult.mapm
   -- WHERE CountResult.loaisach = CountResult.soluongls;
END;

--+************************
















--lấy sách chưa trả
SELECT PM.mapm, ctpm.masach, ctpm.Soluongmuon
FROM PhieuMuon PM
JOIN chitietpm ctpm ON PM.mapm = ctpm.mapm
LEFT JOIN (
  SELECT Pt.mapm, ctpt.masach
  FROM phieutra Pt
  JOIN chitietpt ctpt ON Pt.mapt = ctpt.mapt
) AS Tra ON PM.mapm = Tra.mapm AND ctpm.masach = Tra.masach
WHERE PM.Tinhtrang = N'CHƯA TRẢ' AND Tra.mapm IS NULL;
