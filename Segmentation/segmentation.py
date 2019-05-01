from cv2 import *
import scores_preprocessing as spp
import sys

if len(sys.argv) > 1:
    image_file = sys.argv[1]
else:
    image_file = input("Introduzca el nombre de la imagen a procesar:")

# Loading image
# image = imread("music.png", IMREAD_GRAYSCALE)
spp.process(image_file)
no_lines = imread("no lines.png", IMREAD_GRAYSCALE)
# Blur to make joint sets

blr = GaussianBlur(no_lines, (3, 3), 0)
# imshow("Blurry", blr)

can = Canny(blr, 50, 200)
cont, hierarchy = findContours(can, RETR_EXTERNAL, CHAIN_APPROX_NONE)

squares = []
margin = 5
for border in cont:
    minx = -1
    miny = -1
    maxx = 0
    maxy = 0
    for pixel in border:
        if minx == -1 or pixel[0][0] < minx:
            minx = pixel[0][0]
        if miny == -1 or pixel[0][1] < miny:
            miny = pixel[0][1]
        if pixel[0][0] > maxx:
            maxx = pixel[0][0]
        if pixel[0][1] > maxy:
            maxy = pixel[0][1]
    if minx != maxx and miny != maxy:
        squares.append([int(minx), int(maxx), int(miny), int(maxy)])

# joint_squares = []
# # region Grouping conexe squares
# for i, square1 in enumerate(squares):
#     for j, square2 in enumerate(squares):
#         if i < j and ((square1[0] <= square2[0] and square1[2] <= square2[2]) or
#                       (square1[1] >= square2[1] and square1[3] >= square2[3])):
#             square = []
#             if square1[0] < square2[0]:
#                 square.append(square1[0])
#             else:
#                 square.append(square2[0])
#             if square1[1] > square2[1]:
#                 square.append(square1[1])
#             else:
#                 square.append(square2[1])
#             if square1[2] < square2[2]:
#                 square.append(square1[2])
#             else:
#                 square.append(square2[2])
#             if square1[3] > square2[3]:
#                 square.append(square1[3])
#             else:
#                 square.append(square2[3])
#             joint_squares.append(square2)
#             squares[i] = square
#             square1 = square

# print(len(joint_squares))
# for square in joint_squares:
#     if square in squares:
#         squares.remove(square)
#     if i in squares:
#         squares.remove(i)
#     if j in squares:
#         squares.remove(j)
#     squares.append(new_square)
    # print("Updated")
# endregion

file = open("segments.seg", 'w')
i = 1
for square in squares:
    # print(square)
    # line(image, (square[0], square[2]), (square[0], square[3]), 180)
    # line(image, (square[1], square[2]), (square[0], square[2]), 180)
    # line(image, (square[1], square[2]), (square[1], square[3]), 180)
    # line(image, (square[0], square[3]), (square[1], square[3]), 180)
    # cropped = image[square[2]:square[3], square[0]:square[1]]
    cropped = no_lines[square[2]:square[3], square[0]:square[1]]
    file.write("item "+str(i)+": "+str(square[2])+","+str(square[3])+" "+str(square[0])+","+str(square[1])+"\n")
    imwrite("item "+str(i)+".png", cropped)
    i += 1
