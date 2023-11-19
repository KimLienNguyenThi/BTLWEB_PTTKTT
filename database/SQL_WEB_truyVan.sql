
USE QuanLyThuVien;

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
    PM.HanTra
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
    PM.HanTra;



	SELECT  pm.mapm, pm.mathe, dg.hotendg,dgsdt,ngaymuon, hantra FROM  PHIEUMUON PM JOIN CHITIETPM CTPM ON PM.MAPM =  CTPM.MAPM join docgia dg on pm.mathe=dg.MaDG
WHERE NOT EXISTS ( SELECT  1 FROM CHITIETPT CTPT JOIN PHIEUTRA PT ON CTPT.MAPT = PT.MAPT join docgia dg on pt.mathe=dg.MaDg 
	WHERE     CTPM.MASACH=CTPT.MASACH and PM.MApm =PT.MApm and ctpm.soluongmuon = (select sum(soluongtra+soluongloi) from ChiTietPT ctpt JOIN PHIEUTRA PT ON CTPT.MAPT = PT.MAPT
	group by ctpt.MaPT,ctpt.masach)
	group by pm.mapm, pm.mathe, hotendg,sdt,ngaymuon, hantra

	select * from phieutra --where mapm=12
	select * from chitietpt
	
		select * from sach
		
		
		insert into PhieuMuon ( MaThe, NgayMuon, HanTra,  MaNV) values (5, '2023-11-18', '2023-12-16',2);

-- Them chi tiet phieu muon
insert into ChiTietPM ( MaPM, MaSach, Soluongmuon) values ( 13, 7, 4);
insert into ChiTietPM ( MaPM, MaSach, Soluongmuon) values ( 13, 4, 4);